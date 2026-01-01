import { Link } from "react-router-dom";

type ProductCardProps = {
  id: number;
  name: string;
  price: string;
  image: string;
};

const ProductCard = ({ id, name, price, image }: ProductCardProps) => {
  return (
    <div className="border rounded-xl overflow-hidden bg-white">
      <div className="h-[500px] bg-[#F6EFEA] flex items-center justify-center overflow-hidden rounded-t-xl">
        <img src={image} alt={name} className="w-full h-full object-cover" />
      </div>

      <div className="p-5">
        <h3 className="text-lg font-semibold">{name}</h3>
        <p className="text-sm text-gray-600">{price}</p>

        <Link
          to={`/products/${id}`}
          className="mt-3 inline-block text-[#ba9680]"
        >
          View Product →
        </Link>
      </div>
    </div>
  );
};

export default ProductCard;
