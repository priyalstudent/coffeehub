import React from "react";
import CoffeesRandomImg from "../../public/CoffeesRandom.png";

const ContactUsPage = () => {
  return (
    <div className="max-w-5xl mx-auto px-4 py-16">
      <h1 className="text-3xl font-bold mb-6">Contact Us</h1>

      <p className="text-gray-700 mb-8">
        Have questions or need help? We’d love to hear from you.
      </p>

      <div className="space-y-4 text-gray-700">
        <p>
          <strong>Email:</strong> support@coffeehub.com
        </p>
        <p>
          <strong>Phone:</strong> +32 123 456 789
        </p>
        <p>
          <strong>Support Hours:</strong> Mon–Fri, 10am–6pm
        </p>
      </div>

      <div className="w-full h-[580px] overflow-hidden mt-10">
        <img
          src={CoffeesRandomImg}
          alt="Contact CoffeeHub"
          className="object-cover rounded-xl"
        />
      </div>
    </div>
  );
};

export default ContactUsPage;
