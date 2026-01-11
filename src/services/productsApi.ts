const API_URL = "https://localhost:5197/api/products";

export async function getProducts() {
  const response = await fetch(API_URL);
  if (!response.ok) {
    throw new Error("Failed to fetch products");
  }
  return response.json();
}
