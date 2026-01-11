import { useEffect, useState } from "react";
import ProductCard from "../components/ProductCard";
import { getProducts } from "../services/productsApi";
import { Product } from "../types/Product";
import { Link } from "react-router-dom";

const ProductsPage = () => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [products, setProducts] = useState<Product[]>([]);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    const timer = setTimeout(() => {
      try {
        getProducts().then((data) => {
          setProducts(data);
          setLoading(false);
        });
      } catch {
        setError("Failed to load products.");
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

  const filteredProducts = products.filter((product) =>
    product.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  if (!loading && filteredProducts.length === 0) {
    return (
      <div className="max-w-7xl mx-auto px-4 py-16 text-center">
        <p>No coffees match your search.</p>
      </div>
    );
  }

  return (
    <div className="max-w-7xl mx-auto px-4 py-16">
      <h1 className="text-3xl font-bold mb-8">Our Coffees</h1>

      <input
        type="text"
        placeholder="Search coffee..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        className="w-full max-w-md mb-6 px-4 py-2 border rounded"
      />

      <div className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-3 gap-8">
        {filteredProducts.map((product) => (
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
