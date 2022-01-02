# projet_ecosysteme_3BE_2021 HERITAFITA Samson & ACHOUR Souha
Simulation Ecosysteme


Description (avec justifications) d'au moins deux principes SOLID utilisés dans le projet : 
- S : Principe de la responsabilité unique car chaque classe gère un et un seul élément (je vous invite à voir notre diagramme de classe).  Nos méthodes sont toutes à résponsabilité unique également.
- I : Principe de ségrégation de l’interface. Entres autres, notre interface « IELEMENT » que la classe « Element » hérite en est un bon exemple. Elle hérite des 2 interfaces « ILocalizable » et « ISimulable ». En effet, la localisation et la simulation de l’élément sont gérées de manière indépendante, la modification de la gestion de la position n’impactera pas la simulation. 
- D : principe d’inversion de dépendance. A travers l’interface « ILocalisation », on peut subsitituer  faciliment la classe postion en créant un autre classe qui implémente « ILocalisation » sans impacter la classe « Element ». Pour montrer cela, on a créé volontairement la classe « PositionAlternative » (utilisé dans la ligne n°16 du « main ») qui est équivalent à la classe « Position ». On peut substituer les 2 sans impacter le reste du code.



