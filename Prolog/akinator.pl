:- encoding(utf8).

:- set_prolog_flag(encoding, utf8).
:- set_stream(user_output, encoding(utf8)).

genre(action, 1).
genre(adventure, 2).
genre(rpg, 3).
genre(strategy, 4).
genre(simulation, 5).
genre(sports, 6).
genre(racing, 7).
genre(fighting, 8).
genre(shooter, 9).
genre(puzzle, 10).

platform(pc, 1).
platform(playstation, 2).
platform(xbox, 3).
platform(nintendo, 4).
platform(mobile, 5).

graphics(photorealistic, 1).
graphics(stylized, 2).
graphics(pixel, 3).
graphics(cartoon, 4).

multiplayer(yes, 1).
multiplayer(no, 0).

release(recent, 1). % 2015-2023
release(moderate, 2). % 2005-2014
release(old, 3). % до 2005

game(the_witcher_3, 3, 1, 1, 1, 2).
game(minecraft, 10, 1, 3, 1, 2). 
game(gta_v, 1, 1, 1, 1, 2).
game(fifa_23, 6, 1, 1, 1, 1). 
game(portal_2, 10, 1, 2, 1, 2). 
game(skyrim, 3, 1, 1, 0, 2). 
game(stardew_valley, 5, 1, 3, 0, 1). 
game(tekken_7, 8, 1, 1, 1, 1). 
game(red_dead_2, 1, 1, 1, 0, 1). 
game(among_us, 10, 5, 4, 1, 1). 
game(pokemon_go, 2, 5, 4, 1, 1). 
game(civilization_6, 4, 1, 2, 1, 1). 
game(doom_eternal, 9, 1, 1, 1, 1).
game(mario_kart_8, 7, 4, 4, 1, 1). 
game(the_last_of_us, 2, 2, 1, 0, 2).
game(halo_infinite, 9, 3, 1, 1, 1). 
game(animal_crossing, 5, 4, 4, 1, 1).
game(diablo_3, 3, 1, 2, 1, 2). 
game(tetris, 10, 5, 3, 0, 3). 
game(pacman, 10, 4, 3, 0, 3). 

% Вопросы для пользователя
ask_genre :-
    write("Какой жанр игры вы загадали?"), nl,
    write("1. Action"), nl,
    write("2. Adventure"), nl,
    write("3. RPG"), nl,
    write("4. Strategy"), nl,
    write("5. Simulation"), nl,
    write("6. Sports"), nl,
    write("7. Racing"), nl,
    write("8. Fighting"), nl,
    write("9. Shooter"), nl,
    write("10. Puzzle"), nl,
    read(X), nl,
    asserta(selected_genre(X)).

ask_platform :-
    write("На какой платформе вышла игра?"), nl,
    write("1. PC"), nl,
    write("2. PlayStation"), nl,
    write("3. Xbox"), nl,
    write("4. Nintendo"), nl,
    write("5. Mobile"), nl,
    read(X), nl,
    asserta(selected_platform(X)).

ask_graphics :-
    write("Какая графика в игре?"), nl,
    write("1. Photorealistic"), nl,
    write("2. Stylized"), nl,
    write("3. Pixel"), nl,
    write("4. Cartoon"), nl,
    read(X), nl,
    asserta(selected_graphics(X)).

ask_multiplayer :-
    write("Есть ли мультиплеер?"), nl,
    write("1. Да"), nl,
    write("0. Нет"), nl,
    read(X), nl,
    asserta(selected_multiplayer(X)).

ask_release :-
    write("Когда вышла игра?"), nl,
    write("1. Недавно (2015-2023)"), nl,
    write("2. Средней давности (2005-2014)"), nl,
    write("3. Старая (до 2005)"), nl,
    read(X), nl,
    asserta(selected_release(X)).

guess_game :-
    retractall(selected_genre(_)),
    retractall(selected_platform(_)),
    retractall(selected_graphics(_)),
    retractall(selected_multiplayer(_)),
    retractall(selected_release(_)),
    
    ask_genre,
    ask_platform,
    ask_graphics,
    ask_multiplayer,
    ask_release,
    
    selected_genre(G),
    selected_platform(P),
    selected_graphics(GR),
    selected_multiplayer(M),
    selected_release(R),
    
    game(Name, G, P, GR, M, R),
    
    format("Вы загадали игру: ~w~n", [Name]),

    retractall(selected_genre(_)),
    retractall(selected_platform(_)),
    retractall(selected_graphics(_)),
    retractall(selected_multiplayer(_)),
    retractall(selected_release(_)).

guess_game :-
    write("Не смог угадать вашу игру :("), nl,
    retractall(selected_genre(_)),
    retractall(selected_platform(_)),
    retractall(selected_graphics(_)),
    retractall(selected_multiplayer(_)),
    retractall(selected_release(_)).

start :-
    write("Загадайте игру, а я попробую угадать!"), nl,
    write("Отвечайте на вопросы цифрами, как указано в вариантах ответа."), nl, nl,
    guess_game.