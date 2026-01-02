import { useEffect, useState } from "react";
import ProductCard from "../components/ProductCard";
import { products } from "../data/products";
import { Link } from "react-router-dom";

const ProductsPage = () => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [productsData, setProductsData] = useState(products);

  useEffect(() => {
    const timer = setTimeout(() => {
      try {
        setProductsData(products);
        setError(null);
      } catch {
        setError("Failed to load products.");
      } finally {
        setLoading(false);
      }
    }, 400);

    return () => clearTimeout(timer);
  }, []);

  if (loading) {
    return (
      <div className="text-center py-20 text-lg font-medium">
        Loading coffees...
      </div>
    );
  }

  if (error) {
    return (
      <div className="max-w-7xl mx-auto px-4 py-16">
        <p className="text-center text-red-600">{error}</p>
      </div>
    );
  }

  if (!loading && productsData.length === 0) {
    return (
      <div className="text-center py-20">
        <p className="text-lg">No coffees available at the moment.</p>
      </div>
    );
  }

  return (
    <div className="max-w-7xl mx-auto px-4 py-16">
      <h1 className="text-3xl font-bold mb-8">Our Coffees</h1>

      <div className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-3 gap-8">
        {products.map((product) => (
          <ProductCard
            key={product.id}
            id={product.id}
            name={product.name}
            price={product.price}
            image={product.image}
          />
        ))}
      </div>
    </div>
  );
};

export default ProductsPage;
