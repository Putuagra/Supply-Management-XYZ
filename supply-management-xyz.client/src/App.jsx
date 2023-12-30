import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './App.css';
import VendorPage from './pages/VendorPage';
import LoginForm from './components/vendors/LoginForm';
import Register from './pages/Register';
import VendorUpdatePage from './pages/VendorUpdatePage';

const App = () => {

    return (
        <div className="container">
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<LoginForm /> } />
                    <Route path="/vendor" element={<VendorPage />} />
                    <Route path="/register-vendor" element={<Register />} />
                    <Route path="/update-vendor" element={<VendorUpdatePage />} />
                </Routes>
            </BrowserRouter>
        </div>
    )
}

export default App;