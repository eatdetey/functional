let solve = fun(a,b,c) ->
    let D = b*b-4.*a*c
    ((-b+sqrt(D))/(2.*a),(-b-sqrt(D))/(2.*a));

System.Console.WriteLine(solve(1,-2,1))

