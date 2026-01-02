import { useCart } from "../context/CartContext";
import { Link } from "react-router-dom";

const CartPage = () => {
  const {
    cartItems,
    increaseQuantity,
    decreaseQuantity,
    removeFromCart,
    totalPrice,
  } = useCart();

  if (cartItems.length === 0) {
    return (
      <div className="max-w-4xl mx-auto p-6">
        <h2 className="text-xl font-bold">Your cart is empty</h2>
      </div>
    );
  }

  return (
    <div className="max-w-4xl mx-auto p-6">
      <h1 className="text-2xl font-bold mb-6">Your Cart</h1>

      {cartItems.map((item) => (
        <div key={item.id} className="flex gap-4 mb-4 border-b pb-4">
          <img src={item.image} alt={item.name} className="h-20" />

          <div className="flex-1">
            <h3 className="font-semibold">{item.name}</h3>
            <p className="mt-6 text-lg font-semibold">
              €{(item.price * item.quantity).toFixed(2)}
            </p>

            <div className="flex items-center gap-2 mt-2">
              <button
                onClick={() => decreaseQuantity(item.id)}
                className="px-3 py-1 border rounded"
              >
                −
              </button>

              <span>{item.quantity}</span>

              <button
                onClick={() => increaseQuantity(item.id)}
                className="px-3 py-1 border rounded"
              >
                +
              </button>

              <button
                onClick={() => removeFromCart(item.id)}
                className="ml-4 text-red-600 text-sm"
              >
                Remove
              </button>
            </div>
          </div>
        </div>
      ))}

      <p className="mt-6 text-lg font-semibold">
        Total: €{totalPrice.toFixed(2)}
      </p>
      <Link
        to="/checkout"
        className="inline-block mt-6 bg-[#E6B89C] text-[#3B1F1F] px-6 py-3 rounded font-semibold"
      >
        Proceed to Checkout
      </Link>
    </div>
  );
};

export default CartPage;
