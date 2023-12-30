import { useState } from "react"
import { SetAuth } from "../Auth"
import Button from "../Button"
import Input from "../Input"
import { useNavigate } from 'react-router-dom'
import { login } from "../../apis/AccountVendorApi"
import { getVendorByEmail } from "../../apis/VendorApi"

const LoginForm = () => {

    const navigate = useNavigate()

    const [vendor, setVendor] = useState({
        email: '',
        password: ''
    })

    const handleChange = (e) => {
        const { name, value } = e.target
        setVendor({ ...vendor, [name]: value })
    }

    const handleLoginClick = () => {
        navigate('/vendor')
    }

    const handleRegisterVendorClick = () => {
        navigate("/register-vendor")
    }

    const handleLogin = async () => {
        const vendorLogin = await getVendorByEmail(vendor.email)
        console.log(vendorLogin.data.data)
        try {
            const response = await login(vendor)
            console.log(vendor)
            if (response.code === 200 && vendorLogin.data.data.isAdminApprove && vendorLogin.data.data.isManagerApprove ) {
                console.log('Login berhasil:', response.message)
                const token = response.data
                setVendor({
                    email: '',
                    password: '',
                })
                SetAuth(token)
                handleLoginClick()
            } else {
                alert('registrasi belum di approve')
                console.error('Login gagal:', response.message)
            }
        } catch (error) {
            alert('Email atau password salah')
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault()
        handleLogin()
    }

    return (
        <div className="container-login">
            <div className="login-form">
                <h1>Login</h1>
                <form
                    onSubmit={handleSubmit}
                    className="row g-3 needs-validation"
                >
                    <Input
                        name="email"
                        type="text"
                        placeholder="Email"
                        value={vendor.email}
                        onChange={handleChange}
                    />
                    <Input
                        name="password"
                        type="password"
                        placeholder="Password"
                        value={vendor.password}
                        onChange={handleChange}
                    />
                    <Button
                        name="Login"
                        className="btn btn-primary"
                    />
                </form>
                <div className="row">
                    <div className="col-lg-12">
                        <div className="row">
                            <div className="col-md-6">
                                <Button
                                    name="Registrasi Vendor"
                                    className="btn btn-success"
                                    onClick={handleRegisterVendorClick}
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default LoginForm