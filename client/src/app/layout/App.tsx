import { useEffect, useState } from "react";
import Catalog from "../features/Catalog";
import { Product } from "../models/products";

function App() {
  {/** 
  products använder sig utav egenskaperna vi har angivit i "./models/products.ts",
  typescript kommer att vägrar köra om vi inte fyller i alla egenskaper som speccad.
*/}
  const [products, setProducts] = useState<Product[]>([]); 

useEffect(() => {
  fetch('http://localhost:5000/api/products') // Begär datan från våran .Net API / Swagger
  .then(response => response.json())
  /**
   * Skapar en okänd funktion med response som parameter, 
   * response parametern innehåller det vi får från Swagger. Koppling sker med .then() funktionen som säger att koden ska fortsätta efter fetch();
   * Vi gör API responsen till JSON objekt.
   */
  .then((responseJSON => setProducts(responseJSON)))
  /**
   * Vi koppla på ytterliggare steg med then(); funktionen, responseJSON innehåller föregående JSON objekt.
   * Inuti den okända funktionen så anropar vi react hooksen "useState" och sätter products med setProducts med responseJSON som argument.
   */
}, []);
/**
 * [] hakparentesen betyder att denna useEffect får endast köra engång och inget mer efter App komponenten är mountad.
 * Om vi tarbort hakparentesen då kommer useEffect -> fetch att köras varje gång våran komponent behöver laddas om eller om våran products state ändras.
 * Detta kommer att onödigt belasta API och klienten.
 */

function addProduct () {
  setProducts(prevState => [...prevState, 
    {
    id: prevState.length + 101,
    name: "product" + (prevState.length + 1),
    price: (prevState.length * 100) + 100,
    brand: 'some brand',
    description: 'some description',
    pictureUrl: 'http://picsum.photos/200'
  }])
}
  return (
    <div>
    <h1>Re-Store</h1>
    {/**
     * Skapar två props med varsin värde, den första props "products" innehåller omvandlade JSON objekten från Swagger APIn.
     * den andra props "addProduct" anropar addProduct(); funktionen när den triggas från "./features/Catalog.tsx"
    */}
    <Catalog products={products} addProduct={addProduct}/>
    </div>
  );
}

export default App;