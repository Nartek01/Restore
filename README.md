<h1>Ecommerce Projekt med .Net Core 5</h1>

<h2>Disclaimer: Då jag inte använder version kontroll så mycket på mina privata projekt (och när jag väl använder så gör jag bara en fet commit och pusha upp det..sorry).</h2>

<p>
Projektens ändamål är att skapa en Webbhandel med auktorisation logik.
</p>

<li>
1. Skapa middleware API, så .Net(Backend/Databasen) kan kommunicera med React(Frontend/Userland) ✔️

2. Skapa en class som körs när serverna starta, den ska kontroller om databasen existera och om den gör det är den då tomt? Om den är tomt börja seeda in produkter från superset annars, fortsätta att exkavera kod ✔️

3. Skapa en react framework och fetcha datan från Backend formattera datan till JSON, det kommer underlätta i framtiden om man väljer att gå med någonting annat än React, angular kanske...❌

4. Auktorisation logik, som kollar om användaren är existera och är inloggad, Går att value-checka i frontend eller så POSTas datan till Backend och där kan man också kontrollera.❌

5. Implementera en checkout logik/process med STRIPE payments ❌
</li>
