function Catalog(props: any) { {/** "props" innehåller alla props och dess värde som vi skickat med från "../layout/App.tsx" där vi anropar <Catalog /> komponenten */}
    return (
        <>
        <ul>
          {/** Eftersom vi har tillgång till parametern props som innehåller det propsvärdet vi skickade med så kan vi anropar dom från props.<props från App.tsx>.propsvärde */}
          {props.products.map((product: any) => (<li key={product.id}>{product.name} - {product.price}</li>))}
        </ul>
        {/** Anropar parametern props och funktionen addProduct */}
        <button onClick={props.addProduct}>Add product</button>
      </>
    )
}

export default Catalog