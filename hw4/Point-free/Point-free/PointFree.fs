module PointFree

// Записать в point-free стиле func x l = List.map (fun y -> y * x) l. 
// Выписать шаги вывода и проверить с помощью FsCheck корректность результата

let multiply1 x l = List.map (fun y -> y * x) l

let multiply2 x = List.map (fun y -> y * x)

let multiply3 x = List.map (*) x

let multiply4 = List.map (*)

// let x l = List.map (*) x l