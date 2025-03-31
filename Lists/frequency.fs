module frequency
open readList

let listMax list = 
    match list with 
    |[] -> 0
    | h::t -> reduceList list (fun x y -> if x>y then x else y) (fun x -> true) h

let rec frequency list elem count =
        match list with
        |[] -> count
        | head::tail -> 
            let count1 = count + 1
            if head = elem then frequency tail elem count1 
            else frequency tail elem count

let rec frequencyList list mainList curList = 
        match list with
        | [] -> curList
        | head::tail -> 
            let freqElem = frequency mainList head 0
            let newList = curList @ [freqElem]
            frequencyList tail mainList newList

let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0
            |head::tail ->    
                if (head = el) then num
                else 
                    let num1 = num + 1
                    pos1 tail el num1
    pos1 list el 1

let getIn list pos = 
    let rec getIn1 list num curNum = 
        match list with 
            |[] -> 0
            |head::tail -> 
                if num = curNum then head
                else 
                    let newNum = curNum + 1
                    getIn1 tail num newNum
    getIn1 list pos 1

let f7 list = 
    let fL = frequencyList list list []
    (listMax fL) |> (pos fL) |> (getIn list)   