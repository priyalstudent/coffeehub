import { useCart } from "../context/CartContext";

const CheckoutPage = () => {
  const { cartItems, totalPrice } = useCart();

  return (
    <div className="max-w-6xl mx-auto px-4 py-16">
      <h1 className="text-3xl font-bold mb-8">Checkout</h1>

      {cartItems.length === 0 ? (
        <p>Your cart is empty.</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 gap-12">
          {/* Order Summary */}
          <div>
            <h2 className="text-xl font-semibold mb-4">Order Summary</h2>

            <div className="space-y-4 border rounded-lg p-4">
              {cartItems.map((item) => (
                <div key={item.id} className="flex justify-between text-sm">
                  <span>
                    {item.name} × {item.quantity}
                  </span>
                  <span>€{(item.price * item.quantity).toFixed(2)}</span>
                </div>
              ))}

              <hr />

              <div className="flex justify-between font-semibold">
                <span>Total</span>
                <span>€{totalPrice.toFixed(2)}</span>
              </div>
            </div>
          </div>

          {/* Checkout Form */}
          <div>
            <h2 className="text-xl font-semibold mb-4">Billing Details</h2>

            <form className="space-y-4">
              <input
                type="text"
                placeholder="Full Name"
                className="w-full border px-4 py-2 rounded"
              />

              <input
                type="email"
                placeholder="Email Address"
                className="w-full border px-4 py-2 rounded"
              />

              <input
                type="text"
                placeholder="Shipping Address"
                className="w-full border px-4 py-2 rounded"
              />

              <button
                type="button"
                className="w-full bg-[#E6B89C] text-[#3B1F1F] py-3 rounded font-semibold"
              >
                Place Order
              </button>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};

export default CheckoutPage;
