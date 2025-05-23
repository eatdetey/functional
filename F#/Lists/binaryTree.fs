module binaryTree

type BinaryTree =
    | Empty
    | Node of string * BinaryTree * BinaryTree

let rec insert value tree =
    match tree with
    | Empty -> Node(value, Empty, Empty)
    | Node(v, left, right) ->
        if String.length value < String.length v then
            Node(v, insert value left, right)
        else
            Node(v, left, insert value right)

let rec contains value tree =
    match tree with
    | Empty -> false
    | Node(v, left, right) ->
        if v = value then true
        elif String.length value < String.length v then contains value left
        else contains value right

let rec inorder tree =
    match tree with
    | Empty -> []
    | Node(v, left, right) -> inorder left @ [v] @ inorder right
