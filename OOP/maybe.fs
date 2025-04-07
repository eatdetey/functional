module maybe

type Maybe<'T> =
    | Just of 'T
    | Nothing

let fmap f m =
    match m with
    | Just x -> Just (f x)
    | Nothing -> Nothing

let apply mf mx =
    match mf, mx with
    | Just f, Just x -> Just (f x)
    | _ -> Nothing

let bind m f =
    match m with
    | Just x -> f x
    | Nothing -> Nothing

let functor_identity_test x =
    fmap id x = x

let functor_composition_test x f g =
    fmap (f >> g) x = (fmap g (fmap f x))

let applicative_identity_test v =
    apply (Just id) v = v

let applicative_homomorphism_test f x =
    apply (Just f) (Just x) = Just (f x)

let applicative_interchange_test u y =
    apply u (Just y) = apply (Just (fun f -> f y)) u

let monad_left_identity_test x f =
    bind (Just x) f = f x

let monad_right_identity_test m =
    bind m Just = m

let monad_associativity_test m f g =
    bind (bind m f) g = bind m (fun x -> bind (f x) g)
