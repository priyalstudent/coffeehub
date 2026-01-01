import React from "react";
import homepageCoffee from "../assets/images/homepage-coffee.jpg";
import ProductCard from "../components/ProductCard";
import { products } from "../data/products";

const HomePage = () => {
  return (
    <div>
      <div className="max-w-7xl mx-auto px-4 py-20 grid grid-cols-1 md:grid-cols-2 gap-12 items-center">
        <div>
          <h1 className="text-4xl md:text-5xl font-extrabold text-[#3B1F1F] leading-tight">
            Freshly Brewed Coffee <br />
            Delivered to Your Door
          </h1>

          <p className="mt-6 text-lg text-gray-700 max-w-lg">
            Discover ethically sourced, premium-quality coffee crafted with
            care. From bean to cup — CoffeeHub delivers freshness you can taste.
          </p>

          <div className="mt-8 flex gap-4">
            <button className="bg-[#E6B89C] text-[#3B1F1F] px-6 py-3 rounded-md font-semibold hover:bg-[#d9a679] transition">
              Shop Now
            </button>

            <button className="border border-[#3B1F1F] text-[#3B1F1F] px-6 py-3 rounded-md font-semibold hover:bg-[#3B1F1F] hover:text-white transition">
              Learn More
            </button>
          </div>
        </div>

        <div className="flex justify-center">
          <div className="w-80 h-80 rounded-full overflow-hidden shadow-lg">
            <img
              src={homepageCoffee}
              alt="Freshly brewed coffee "
              className="w-full h-full object-cover"
            />
          </div>
        </div>
      </div>

      <div className="max-w-7xl mx-auto px-4 py-16">
        <h2 className="text-2xl font-bold mb-8">Featured Coffees</h2>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {products.slice(0, 3).map((product) => (
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
    </div>
  );
};

export default HomePage;
