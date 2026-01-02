import { useParams } from "react-router-dom";
import { useState } from "react";
import { products } from "../data/products";
import { useCart } from "../context/CartContext";

const ProductDetailPage = () => {
  const [quantity, setQuantity] = useState(1);
  const [added, setAdded] = useState(false);
  const { id } = useParams();
  const { addToCart } = useCart();
  const product = products.find((item) => item.id === Number(id));

  if (!product) {
    return (
      <div className="max-w-4xl mx-auto px-4 py-10">
        <h2 className="text-xl font-bold">Product not found</h2>
      </div>
    );
  }

  return (
    <div className="max-w-3xl mx-auto m-6 py-8 my-8 px-4 border rounded-xl overflow-hidden bg-white">
      <div className="w-full bg-[#F6EFE8] flex justify-center">
        <img
          src={product.image}
          alt={product.name}
          className="w-auto max-h-[420px] object-contain"
        />
      </div>

      <div className="p-5">
        <h1 className="text-3xl font-bold">{product.name}</h1>
        <p className="mt-3 text-gray-600">{product.description}</p>
        <p className="text-xl mt-4">
          Total: €{(product.price * quantity).toFixed(2)}
        </p>

        <div className="flex items-center gap-4 mt-4">
          <button
            onClick={() => setQuantity((q) => Math.max(1, q - 1))}
            className="px-4 py-2 border rounded"
          >
            −
          </button>

          <span className="text-lg font-medium">{quantity}</span>

          <button
            onClick={() => setQuantity((q) => q + 1)}
            className="px-4 py-2 border rounded"
          >
            +
          </button>
        </div>

        <button
          onClick={() => {
            addToCart({
              id: product.id,
              name: product.name,
              price: Number(product.price),
              image: product.image,
              quantity: quantity,
            });
            setAdded(true);
            setTimeout(() => setAdded(false), 2000);
          }}
          className="mt-6 bg-[#E6B89C] text-[#3B1F1F] px-6 py-3 rounded"
        >
          Add to Cart
        </button>
        {added && (
          <p className="mt-3 text-green-600 font-medium">✓ Added to cart</p>
        )}
      </div>
    </div>
  );
};

export default ProductDetailPage;
