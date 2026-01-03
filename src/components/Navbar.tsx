import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { useCart } from "../context/CartContext";

const Navbar = () => {
  const { cartCount } = useCart();
  const { user, logout } = useAuth();

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
          <Link to="/cart">
            Cart
            {cartCount > 0 && (
              <span className="ml-2 bg-[#E6B89C] text-black px-2 py-0.5 rounded-full text-xs">
                {cartCount}
              </span>
            )}
          </Link>

          {!user ? (
            <>
              <Link to="/login">Login</Link>
              <Link to="/register">Register</Link>
            </>
          ) : (
            <>
              <span className="text-sm">Hi, {user.name}</span>
              {user.role === "admin" && (
                <Link to="/admin" className="hover:text-[#E6B89C] transition">
                  Admin
                </Link>
              )}
              <button onClick={logout} className="text-sm underline">
                Logout
              </button>
            </>
          )}
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
