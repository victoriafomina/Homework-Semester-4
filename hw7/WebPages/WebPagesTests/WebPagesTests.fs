module WebPagesTests

open NUnit.Framework
open WebPages
open FsUnit

let testCases1 =
    [
        "https://vk.com/"
        "https://meow.com/"
        "https://www.linkedin.com/"
    ] |> List.map (fun url -> TestCaseData(url)) 

let testCases2 =
    [
        "https://meow.com/"
        "vsykayDich"
        "http://dich.com/"
    ] |> List.map (fun url -> TestCaseData(url)) 

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Smoke tests`` url =
    url |> download |> List.length |> should greaterThan 0

[<Test>]
[<TestCaseSource("testCases2")>]
let ``Download should return empty list`` url =
    url |> download |> List.length |> should equal 0