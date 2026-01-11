const AdminDashboardPage = () => {
  return (
    <div className="max-w-6xl mx-auto px-4 py-16">
      <h1 className="text-3xl font-bold mb-4">Admin Dashboard</h1>

      <p className="text-gray-600 mb-8">
        This area is only accessible to administrators.
      </p>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div className="border rounded p-4">
          <h2 className="font-semibold">Manage Products</h2>
          <p className="text-sm text-gray-500">Add, edit, or remove coffees</p>
        </div>

        <div className="border rounded p-4">
          <h2 className="font-semibold">Orders</h2>
          <p className="text-sm text-gray-500">View customer orders</p>
        </div>

        <div className="border rounded p-4">
          <h2 className="font-semibold">Users</h2>
          <p className="text-sm text-gray-500">Manage user roles</p>
        </div>
      </div>
    </div>
  );
};

export default AdminDashboardPage;
