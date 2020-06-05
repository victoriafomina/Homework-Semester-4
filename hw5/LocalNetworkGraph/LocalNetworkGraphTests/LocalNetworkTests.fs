module LocalNetworkGraphTests

open NUnit.Framework
open LocalNetwork
open FsUnit

let testCases1 =
    [
        [[1]; [0]], ["Linux"; "Windows"], [0.3; 0.7], [0; 1]
        [[1]; [0]], ["Linux"; "Windows"], [1.0; 1.0], [0; 1]
        [[1]; [0]], ["Mac OS"; "Linux"], [0.7; 0.0], [0]
        [[1; 3]; [0]; [3]; [2; 1]], ["Windows"; "Linux"; "Linux"; "Mac OS"], [0.7; 0.1; 0.1; 0.9], [0; 1; 2; 3]
        [[1; 2; 3; 4]; [0; 2; 3; 4]; [0; 1; 3; 4]; [0; 1; 2; 3]; [0; 1; 2; 3; 4]], 
                ["WIndows"; "Windows"; "Linux"; "Linux"; "Mac OS"], [0.5; 0.5; 0.2; 0.2; 1.0], [0; 1; 2; 3; 4]
    ] |> List.map (fun (communicationComputers, operSys, probabOfInf, infected) -> 
            TestCaseData(communicationComputers, operSys, probabOfInf, infected))

let testCases2 = 
    [
        [[1]; [0]], ["Linux"; "Windows"], [0.0; 0.0]
        [[1; 2; 3; 4]; [0; 2; 3; 4]; [0; 1; 3; 4]; [0; 1; 2; 3]; [0; 1; 2; 3; 4]], 
                ["WIndows"; "Windows"; "Linux"; "Linux"; "Mac OS"], [0.0; 0.0; 0.0; 0.0; 0.0]
    ] |> List.map (fun (communicationComputers, operSys, probabOfInf) -> 
        TestCaseData(communicationComputers, operSys, probabOfInf))

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Checks if contains vertexes that should be infected`` communication operSys probabOfInf infected =
    LocalNetwork(communication, operSys, probabOfInf).Infected |> List.forall (List.contains infected) |> should equal true

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Checks if vertexes that should be infected are contained in result`` communication operSys probabOfInf infected =
    List.forall(fun x -> LocalNetwork(communication, operSys, probabOfInf).Infected |> List.contains infected |> should equal true

[<Test>]
[<TestCaseSource("testCases2")>]
let ``Checks if the algorithm works correctly when probabylity of infection is 0 for all computers`` communication operSys probabOfInf =
    LocalNetwork(communication, operSys, probabOfInf).Infected |> List.length = 0 |> should equal true