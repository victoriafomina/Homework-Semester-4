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
    ] |> List.map (fun (communicationComputers, operSys, probabOfInf, infected) -> 
            TestCaseData(communicationComputers, operSys, probabOfInf, infected))

let testCases2 = 
    [
        [[1]; [0]], ["Linux"; "Windows"], [0.0; 0.0]
    ] |> List.map (fun (communicationComputers, operSys, probabOfInf) -> 
        TestCaseData(communicationComputers, operSys, probabOfInf))

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Checks if the algorithm of infection works correctly`` communication operSys probabOfInf infected =
    LocalNetwork(communication, operSys, probabOfInf).Infect.TrueForAll(fun x -> List.contains x infected) |> should equal true

[<Test>]
[<TestCaseSource("testCases2")>]
let ``Checks if the algorithm works correctly when probabylity of infection is 0 for all computers`` communication operSys probabOfInf =
    LocalNetwork(communication, operSys, probabOfInf).Infect.Count = 0 |> should equal true