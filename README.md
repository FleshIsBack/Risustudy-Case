# Risustudy-Case

**Frontend:** https://risustudy-case-t8c1.vercel.app  
**Backend API:** https://backendapi20260429202502-a6g9a9fga0g4aygs.canadacentral-01.azurewebsites.net  
**GitHub:** https://github.com/FleshIsBack/Risustudy-Case

---

## 1. Identificerede lærer-behov

Lærere i folkeskolen har typisk 25-30 elever per klasse. Det primære problem er overblik, det er svært at holde styr på hvilke elever der er bagud, hvilke der trives, og hvad man som lærer skal gøre ved det.

**"Hvad sker der i min klasse?"**  
Læreren har brug for et hurtigt overblik over hele klassens progression uden at skulle klikke ind på hver enkelt elev manuelt.

**"Hvorfor klarer en elev sig som de gør?"**  
Når en elev enten halter bagud eller klare det godt, vil læreren gerne forstå "hvorfor", hvilke faglige områder er eleven svag, hvilke på hvilke områder stærk, og hvad er tendensen over tid.

**"Hvordan kan jeg håndtere udviklen"**  
Læreren har ikke altid tid til selv at analysere data og agere på det. AI-genererede anbefalinger kan hjælpe læreren med at prioritere sin indsats.

---

## 2. Valgte features

### Feature 1: Class Performance Overview
Et samlet overblik over klassens elever med AI genererede statustags (Advanced, On Track, Needs Attention) og en fremdriftsindikator per elev. Læreren kan klikke på en elev for direkte at navigere til den pågældende elevs detailjer.

**Endpoint:** `GET /api/classes/{classId}/performance`

### Feature 2: Student Learning Insights
Et dybdegående kig på en enkelt elevs læringsprofil med AI-genereret analyse, svage og stærke emner samt en læringstendens (improving / stable / declining).

**Endpoint:** `GET /api/students/{studentId}/insights`

### Feature 3: Teacher Action Recommendations
AI-genererede handlingsforslag til læreren, prioriteret efter vigtighed. Hvert forslag indeholder en type (intervention, gruppering, opgave, tjek-ind), de berørte elever og den forventede effekt.

**Endpoint:** `GET /api/classes/{classId}/recommendations`

---

## 3. Fravalgte features

**Authentication og login**  
Ville kræve betydelig infrastruktur (JWT, roller, sessions) og tilføjer ingen demonstrationsværdi i en prototype. I produktion ville dette være første prioritet.

**Database og persistering**  
Al data er mocket i `MockData.cs`. En reel implementation ville bruge Entity Framework Core med PostgreSQL. Fravalgt da opgaven eksplicit tillader mock-data, og det ville tage uforholdsmæssigt lang tid.

**CRUD-operationer**  
Prototypen er read-only. Lærere kan ikke oprette, redigere eller slette data. I en reel løsning ville "Take Action" på anbefalinger resultere i et POST-kald der logger handlingen og opdaterer anbefalingens status.

**AI-integration**  
AI-analysen er simuleret via hardkodet tekst. I produktion ville dette integrere med et/jeres LLM baseret på elevens faktiske præstationsdata.

**Kompleks datamodellering**  
Modellerne er bevidst holdt simple og fokuserede på det der er nødvendigt for at demonstrere de tre features. Dette følger YAGNI-princippet.

---

## 4. Arkitekturvalg og designprincipper

### Designprincipper

**SRP (Single Responsibility Principle)**  
Hver controller håndterer en feature. `ClassPerformanceController` kender ikke til anbefalinger, og `RecommendationController` kender ikke til elever. Services indeholder forretningslogik, controllers håndterer kun HTTP.

---

## 5. Hvad ville jeg dernæst prioritere 

Hvis jeg havde haft mere tid og skulle implementere et fuldendt system ville jeg komme igennem mange af mine fravalgte emner da de er essentielle til et reelt system. Dog ville jeg prioritere i følgende rækkefølge:

**1. Auth/sikkerhed integration**  
For at systemet skal kunne komme i produktion krævers det at det sikkerhedsmæssigt opfylder  GDPR lovgivning og det skal sikres så sårbar information ikke bliver lækket til de forkerte.

**2. Database**  
Entity Framework Core med PostgreSQL ville erstatte MockData og gøre det muligt at persistere handlinger og tilstande.

**3. Designe et mere fuldendt system**  
Designe et mere fuldendt system allerede inden kode delen begynder. Dette kan øge hastigheden af iterationer med sparring sammen med en product owner og sikre at arkitekturen holder når systemet vokser.

**4. CRUD**  
Med en database og domænemodel på plads ville næste skridt være at lærenen kan interagere med systemet ved at kunne - læse, redigere, oprette og slette data.

**5. AI-implementering**  
Nu hvor data er reel og persisteret kan AI analysere elevernes faktiske præstationsdata i stedet for hardkodet tekst. Dette ville integrere med et LLM baseret på elevens løbende resultater.

**6. Dynamisk klasse-valg**  
I stedet for hardkodet classId ville læreren kunne skifte mellem sine klasser via en dropdown i sidebaren.
