Ce este un viewport?
Viewport-ul este zona din fereastra aplicatiei unde se deseneaza scena 3D. El determina ce parte din scena este vizibila pe ecran.

Ce reprezinta FPS in OpenGL?
FPS (frames per second) masoara cate cadre sunt generate pe secunda. Un numar mai mare de FPS inseamna o redare mai fluida a animatiilor.

Cand este rulata metoda OnUpdateFrame()?
OnUpdateFrame() este rulata de fiecare data cand aplicatia se actualizeaza, inainte de a desena urmatorul cadru. Aici se fac modificari in starea jocului.

Ce este modul imediat de randare?
Modul imediat de randare este o tehnica in care fiecare element grafic este desenat direct pe ecran, fara stocare intermediară. Este mai simplu, dar mai putin eficient.

Care este ultima versiune de OpenGL care accepta modul imediat?
Ultima versiune care accepta modul imediat este OpenGL 2.1. Dupa aceasta versiune, s-au promovat metode mai moderne de randare.

Cand este rulata metoda OnRenderFrame()?
OnRenderFrame() este apelata in fiecare ciclu de redare, dupa ce aplicatia a fost actualizata. Aici se deseneaza efectiv scena pe ecran.

De ce trebuie sa fie executata metoda OnResize() cel putin o data?
OnResize() trebuie apelata cel putin o data pentru a actualiza dimensiunile viewport-ului si proiecția, asigurandu-se ca totul este corect redat pe ecran.

Ce reprezinta parametrii metodei CreatePerspectiveFieldOfView()?
Aceasta metoda stabileste cum se vede scena 3D. Parametrii includ:

FOV: unghiul de vedere.
Aspect Ratio: raportul latime/inaltime al ferestrei.
Near Plane: distanta de la camera la obiectele apropiate.
Far Plane: distanta la obiectele indepartate.
FOV este intre 0 si 180 de grade, iar pentru near si far, near trebuie sa fie mai mic decat far, iar ambele trebuie sa fie pozitive.