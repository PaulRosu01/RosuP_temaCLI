1.	In OpenGL, ordinea varfurilor afecteaza orientarea poligoanelor si vizibilitatea acestora. Ordinul orar (CW) se deseneaza in sensul acelor de ceasornic, iar cel anti-orar (CCW) in sens invers. OpenGL foloseste implicit ordinul anti-orar pentru fatetele frontale (glFrontFace(GL_CCW)).

2. Anti-aliasing este o tehnica folosita in grafica pentru a face marginile obiectelor mai netede. Cand o linie oblica sau curbita este afisata pe un ecran cu pixeli patrati, marginea poate parea "dintata" (efectul de aliasing). Anti-aliasing-ul reduce acest efect prin amestecarea culorilor pixelilor de la margine, creand o tranzitie mai fina intre obiect si fundal, rezultand o imagine mai clara, fara contururi "dintate".

3. In OpenGL, comenzile GL.LineWidth(float) si GL.PointSize(float) controleaza grosimea liniilor si dimensiunea punctelor. GL.LineWidth(float width) seteaza grosimea liniilor desenate ulterior, iar GL.PointSize(float size) seteaza dimensiunea punctelor. Ambele comenzi functioneaza in interiorul unui bloc GL.Begin() - GL.End(), aplicand aceleasi valori pana cand sunt modificate.

4. 
a. LineLoop: Utilizarea directivei LineLoop in OpenGL creeaza un poligon inchis, conectand automat ultimul varf cu primul. Aceasta este utila pentru a desena forme inchise fara a specifica explicit legaturile.

b. LineStrip: Directivele LineStrip permit desenarea unei serii de segmente de dreapta conectate. Fiecare varf este conectat la precedentul, formand o linie continua, dar nu este inchisa.

c. TriangleFan: Utilizarea directivei TriangleFan in OpenGL permite desenarea unui poligon convex printr-o serie de triunghiuri care impart acelasi varf central. Aceasta metoda este eficienta pentru a crea forme circulare sau curbe.

d. TriangleStrip: Directivele TriangleStrip permit desenarea unei serii de triunghiuri conectate. Fiecare nou triunghi imparte doi varfuri anteriori si adauga un nou varf, reducand numarul de varfuri necesare pentru a descrie forme complexe.


6. Utilizarea culorilor diferite in desenarea obiectelor 3D este esentiala pentru evidentierea formei si adancimii. Când fiecare fateta a unui obiect 3D are o culoare specifica, este mai usor de inteles limitele acestuia. Un gradient sau culori variate contribuie la o iluminare mai realista, facand obiectele sa para mai dinamice si naturale, imbunatatind experienta vizuala.

7. Un gradient de culoare este o trecere lina intre doua sau mai multe culori, utilizata pentru a face obiectele mai naturale. In OpenGL, un gradient se obtine atribuind culori diferite fiecarui varf al unui poligon folosind comanda glColor. OpenGL interpoleaza automat culorile intre varfuri, creand o tranzitie treptata pe suprafata poligonului.

10. Utilizarea unei culori diferite pentru fiecare vertex atunci cand desenati o linie sau un triunghi in modul strip creeaza un gradient de culoare. OpenGL interpoleaza automat culorile intre varfuri, rezultand o tranzitie lina si estetica. Aceasta evidentiaza forma si adancimea obiectului, conferindu-i un aspect dinamic si atractiv.
