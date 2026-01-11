import React from "react";

const Footer = () => {
  return (
    <footer className="mt-20">
      {/* Top Info Strip */}
      <div className="bg-[#F6E3C5] py-10">
        <div className="max-w-7xl mx-auto px-4 grid grid-cols-1 md:grid-cols-3 gap-4 text-center">
          <div>
            <h3 className="font-semibold text-lg">Online Support</h3>
            <p className="text-sm mt-2">
              Call or WhatsApp us Mon–Fri, 10am–6pm
            </p>
          </div>

          <div>
            <h3 className="font-semibold text-lg">COD Available</h3>
            <p className="text-sm mt-2">Cash on Delivery available</p>
          </div>

          <div>
            <h3 className="font-semibold text-lg">Worldwide Delivery</h3>
            <p className="text-sm mt-2">Delivered in 17-20 business days</p>
          </div>
        </div>
      </div>

      {/* Main Footer */}
      <div className="bg-[#3B1F1F] text-white py-14">
        <div className="max-w-7xl mx-auto px-4 grid grid-cols-1 md:grid-cols-4 gap-10">
          {/* Brand */}
          <div>
            <h2 className="text-xl font-bold">CoffeeHub</h2>
            <p className="text-sm mt-4 text-gray-300">
              Premium coffee crafted with care. Ethically sourced, freshly
              roasted, and delivered to your door.
            </p>
            {/* SocialMedia Links */}
            <div>
              <li></li>
              <li></li>
              <li></li>
            </div>
          </div>

          {/* Policies */}
          <div>
            <h3 className="font-semibold mb-4">Our Policies</h3>
            <ul className="space-y-2 text-sm text-gray-300">
              <li>Privacy Policy</li>
              <li>Terms & Conditions</li>
              <li>Shipping & Cancellation</li>
              <li>Returns & Refund</li>
            </ul>
          </div>

          {/* Information */}
          <div>
            <h3 className="font-semibold mb-4">Information</h3>
            <ul className="space-y-2 text-sm text-gray-300">
              <li>Shop</li>
              <li>About Us</li>
              <li>Contact Us</li>
            </ul>
          </div>

          {/* Newsletter */}
          <div>
            <img src="/logo.png" alt="CoffeeHub Logo" className="h-10 w-auto" />
            <h3 className="font-semibold mb-4">Sign up for offers</h3>
            <input
              type="email"
              placeholder="Your email"
              className="w-full px-3 py-2 rounded text-black text-sm"
            />
          </div>
        </div>
      </div>

      {/* Bottom Bar */}
      <div className="bg-[#2A1414] text-gray-400 text-sm text-center py-4">
        © {new Date().getFullYear()} CoffeeHub. All rights reserved.
        <div className="fa-solid fa-code" aria-hidden="true">
          <li>Designed & Coded by Priyal Patel</li>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
