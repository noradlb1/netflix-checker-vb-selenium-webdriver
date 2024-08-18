Imports OpenQA.Selenium

Public Module ExpectedConditions
    Public Function ElementIsVisible(ByVal locator As By) As Func(Of IWebDriver, IWebElement)
        Return Function(driver)
                   Dim element = driver.FindElement(locator)
                   Return If(element.Displayed, element, Nothing)
               End Function
    End Function

    Public Function ElementToBeClickable(ByVal locator As By) As Func(Of IWebDriver, IWebElement)
        Return Function(driver)
                   Dim element = driver.FindElement(locator)
                   Return If(element.Enabled AndAlso element.Displayed, element, Nothing)
               End Function
    End Function
End Module