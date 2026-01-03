import { createContext, useContext, useState } from "react";

type User = {
  id: number;
  name: string;
  email: string;
  role: "user" | "admin";
};

type AuthContextType = {
  user: User | null;
  login: (email: string, password: string) => Promise<void>;
  register: (name: string, email: string, password: string) => Promise<void>;
  logout: () => void;
  loading: boolean;
  error: string | null;
};

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const login = async (email: string, password: string) => {
    setLoading(true);
    setError(null);

    await new Promise((res) => setTimeout(res, 800));

    if (password !== "admin" && password !== "user") {
      setError("Invalid credentials");
      setLoading(false);
      return;
    }

    setUser({
      id: email === "admin@coffeehub.com" ? 1 : 2,
      name: email === "admin@coffeehub.com" ? "Admin" : "User",
      email,
      role: email === "admin@coffeehub.com" ? "admin" : "user",
    });

    setLoading(false);
  };

  const register = async (name: string, email: string, password: string) => {
    setLoading(true);
    setError(null);

    await new Promise((res) => setTimeout(res, 800));

    setUser({ id: Date.now(), name, email, role: "user" });
    setLoading(false);
  };

  const logout = () => setUser(null);

  return (
    <AuthContext.Provider
      value={{ user, login, register, logout, loading, error }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth must be used inside AuthProvider");
  return ctx;
};
