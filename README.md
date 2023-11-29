# Tietokantojen hyodyntaminen
[Tietokantayhteyden luoti C#:ssa](https://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C) 

Gradia tietokantojen-hyodyntaminen kurssin arkisto (repository).

Tällä kurssia käytämme Microftin SQL-tietokantaa osana tehtäviä sovelluksia. Kehitysympäristönä toimii Visual Studio 2022 Community versio. Tietokannan käsitteltyä varten kannattaa ladata oma työkalu osoitteesta https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

Jokainen tehtävä sijoitetaan tänne omaan hakemistoonsa. 

# Aikataulu, tavoitteet ja oman osaamisen arviointi

Kurssi kestää neljä viikkoa. Suositeltava työtahti olisi seuraavanlainen:
- Tee tehtävä yksi ensimmäisen viikon aikana. Jos jäät jumiin vaikeisiin LINQ-tehtäviin mene eteenpäin ja palaa niihin myöhemmin. Ideaalissa tilanteessa pääset
  aloittamaan tehtävän kaksi ensimmäisen viikon lopulla. (T1)
- Tee tehtävä kaksi toisen viikon aikana. (T2)
- Tehtävään kolme voi käyttää aikaa yhdestä kahteen viikkoon riippuen siitä miten kattavan tehtävästä haluaa. Kurssin kiitettävä kriteerit täyttyvät tekemällä 
  autotehtävän kaikki kohdat (H3-K5).
- Bonus: Jos sinulle jää aikaa, valitse joko tehtävä neljä tai viisi. (K5+)


# Git ohje

# SSH avaimen luonti Githubia varten
Perjantaina 13. elokuuta 2022 Github muutti kirjautumisvaatimuksiaan ja login/salasana kirjautuminen ei enää toimi. Tämän takia luomme kaikille SSH avaimet ja käytämme niitä autentikointiin Githubin kanssa.
**HUOM! Jos pääset normaalisti kirjautumaan Githubiin ei SSH avaimiin siirtyminen ole pakollista. Tee siis nämä vaiheet vain jos Github ei enää päästä sinua sisään!**

1. Avaa GitBash ```olio-ohjelmointi-2022-kevat``` hakemistossa.
2. Kokeile komentoa ```ssh -T git@github.com```. Mikäli komennon vastauksesta löytyy kohta ```...You've successfully authenticated...``` olet valmis eikä tätä ohjetta tarvitse seurata pidemmälle. Mikäli autentikointi taas epäonnistuu jatka kohtaan 3.
3. ```ls ~/.ssh``` - Mikäli komento onnistuu ja tulostaa hakemiston josta löytyy tiedostot ```id_rsa``` ja ```id_rsa.pub``` hyppää kohtaan 5. Mikäli tiedostot puuttuvat tai koko ```.ssh``` hakemisto puuttuu siirry kohtaan 4.
4. ```ssh-keygen -t rsa -b 2048``` - Vastaa jokaiseen kysymykseen painamalla enteriä (älä siis muuta oletusvastauksia.)
5. ```ls ~/.ssh``` - Nyt komennon pitäisi tulostaa hakemisto josta löytyy tiedostot ```id_rsa``` ja ```id_rsa.pub```.
6. ```cat ~/.ssh/id_rsa.pub``` - Tulostaa konsoliin julkisen avaimesi. Kopioi avain talteen. Esimerkki avaimesta alla.
7. Mene githubin avaintenhallintasivulle ```https://github.com/settings/keys```
8. Klikkaa vihreää "New SSH key" painiketta.
9. Keksi avaimelle nimi "Title" kenttään.
10. Liitä kohdassa 6 kopioimasi avain "Key" kenttään.
11. Klikkaa vihreää "Add SSH key" painiketta.
12. Kokeile GitBashissa että yhteys toimii nyt: ```ssh -T git@github.com```. Mikäli komennon vastauksesta nyt löytyy kohta ```...You've successfully authenticated...``` siirry kohtaan 13. Muussa tapauksessa ota yhteyttä opettajaan. Jos ssh valittaa ettei tunne githubin palvelinta ja kysyy haluatko varmasti lisätä tämän palvelimen tunnettujen palvelimien listalle, vastaa ```yes``` (kirjoita sana yes kokonaan).

*Esimerkki kohdan 6. ja 10. avaimesta:*
```
ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDdFIDeYjLcmRENhfZC16feD6/TJ1WrpSAfBkxr2v2+u5tbiNsSHLLV0rhqwmajZXkEBSjL97PyT3LVNemMa82BI3BB53t5An61DO8GgP0IY+jQef6P5HoFnfD2Pxu4PxpAjse5dZaZa7GR8nyLEzYUh38C+/p7H5eMNolZiSqgPHFtPDXwa6GvY2gYUDdhFGZmNMXFZ3sTVMjtdA/CDsO4kNCG8CFddTsFsrBhiS1j9nvARd2MgaN+3EL5beehTjr1/BZqyRc5vcfM2SUCqaFbdxq6Y1dXfGGLzNrwvVCa36a4LrNOoeQn930Ay15VhQ8xKBIta/IQY42e2RFfzeiN karri@sanxion
```

# Repositorion kloonaaminen omalle koneelle
Tämä tehdään vain kerran kurssin aluksi. Olet saanut itsellesi linkin github-classroomiin, joka luo sinulle automaattisesti repositoryn. Valitse oma nimesi listasta.

1. Avaa GitBash hakemistoon jonka alle haluat tehtäväkansion. Tämä onnistuu klikkaamalla oikealla hiirennapilla hakemistoa Windows Explorerissa ja valitsemalla "Avaa GitBash tässä."
2. kirjoita komento```git clone``` "oman repon nimi joka löytyy yläosan Code napin takaa" esim. minun toisella tililläni sen näyttäisi seuraavanlaiselta: git@github.com:Gradia-Ohjelmistokehitys-k2022/tietokantojen-hyodyntaminen-vilbohamalainen.git

# Uusien tehtävänantojen hakeminen
Kaikki tämä tehdään GitBashissä harjoitustehtävän hakemistossa.
1. ```git status``` - tarkista että olet main haarassa (branch), ja että sinulla ei ole avoimia muutoksia (jotka näkyvät punaisena tai vihreänä). Mikäli niitä on, tallenna ne ensin komennoilla ```git add .```, ```git commit -m "Muutokset talteen."```.
2. <mark>Tämä tehdään vain kerran.</mark> Lisätään alkuperäinen pohja haettavaksi seuraavalla komennolla, jos muutoksia materiaaleihin tulee.```git remote add upstream https://github.com/Gradia-Ohjelmistokehitys-k2022/tietokantojen-hyodyntaminen-pohja.git```
3. Haetaan uusin versio upstreamista ``git pull upstream main --allow-unrelated-histories`` --allow-unrelated-histories voi ratkaista githubclassroomiin liittyviä ongelmia.
4. Varmista, että olet main branchissa seuraavalla komennolla```git checkout main```


# Oman työn palauttaminen
Kaikki tämä tehdään GitBashissä harjoitustehtävän hakemistossa.
1. ```git status``` - tarkista että olet omassa haarassa (branch), ja että sinulla ON avoimia muutoksia (jotka näkyvät punaisena).
2. ```git add .```
3. ```git status``` - tarkista että muutokset näkyvät nyt vihreinä.
4. ```git commit -m "Tehtävän <se ja se> palautus."``` - laita palauttamasi tehtävän nimi ja/tai numero kommenttiin.
5. ```git push``` 

# Muita hyödyllisiä komentoja GitBashissä

## ```cd```
Siirtyy toiseen hakemistoon, esim. ```cd 00_Hevonen``` siirtyy hakemistoon ```00_Hevonen```

## ```ls```
Listaa nykyisen hakemiston sisällön, eli tässä hakemistossa olevat tiedostot ja hakemistot.

## ```git status```
Kertoo missä haarassa (branch) olet, ja mitä tiedostoja olet muokannut (näkyy punaisena), mitkä on merkitty (staged) lisättäväksi repositorioon (näkyy vihreänä). Lisäksi komento kertoo onko oma kopiosi haarasta samalla tasolla kuin GitHub palvelimella oleva, vai onko sinulla paikallisia muutoksia joita et ole vielä työntänyt (push) palvelimelle.

## ```git log```
Listaa nykyisen haarasi (branchin) viimeisimmän version, sekä kaikki sitä suoraan edeltävät versiot.

## ```git log --graph --all --decorate```
Piirtää konsoliin graafin koko repositorion sisällöstä. Kaikkien haarojen kaikki versiot yhtenä (isona) tekstigrafiikkakuvana.


