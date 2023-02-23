import { useEffect, useState } from "react";

function App() {
  const [products, setProducts] = useState([
  {name: "product1", price: 100.00},
  {name: "product2", price: 200.00}
]);

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

function addProducts () {
  //setProducts([...products, {name: "product3", price: 300.00}]);
  setProducts(prevState => [...prevState, {name: "product" + (prevState.length + 1), price: (prevState.length * 100) + 100}]);
}
  return (
    <div>
      <h1>Re-Store</h1>
      <ul>
        {products.map((item,index) => (<li key={index}>{item.name} - {item.price}</li>))}
      </ul>
      <button onClick={addProducts}>Add product</button>
    </div>
  );
}

export default App;