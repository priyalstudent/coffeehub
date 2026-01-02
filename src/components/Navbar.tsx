import { Link } from "react-router-dom";
import { useCart } from "../context/CartContext";

const Navbar = () => {
  const { cartCount } = useCart();

  return (
    <nav className="bg-[#3B1F1F] text-white">
      <div className="max-w-7xl mx-auto px-4 py-4 flex items-center justify-between">
        <Link to="/" className="flex items-center gap-2">
          <img src="/logo.png" alt="CoffeeHub Logo" className="h-10 w-auto" />
          <span className="text-xl font-bold tracking-wide">CoffeeHub</span>
        </Link>

        <div className="flex items-center gap-6 text-sm font-medium">
          <Link to="/" className="hover:text-[#E6B89C] transition">
            Home
          </Link>
          <Link to="/products" className="hover:text-[#E6B89C] transition">
            Products
          </Link>
          <Link to="/aboutus" className="hover:text-[#E6B89C] transition">
            About
          </Link>
          <Link to="/contactus" className="hover:text-[#E6B89C] transition">
            Contact
          </Link>
        </div>

        <div className="flex items-center gap-4 text-sm">
          <Link to="/login" className="hover:text-[#E6B89C] transition">
            Login
          </Link>
          <Link
            to="/cart"
            className="relative inline-flex items-center hover:text-[#E6B89C] transition"
          >
            <span>Cart</span>
            {cartCount > 0 && (
              <span className="ml-1 flex items-center justify-center min-w-[18px] h-[18px] bg-[#E6B89C] text-black text-xs font-semibold rounded-full px-1">
                {cartCount}
              </span>
            )}
          </Link>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
