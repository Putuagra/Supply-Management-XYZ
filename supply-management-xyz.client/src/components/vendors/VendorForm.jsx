import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import Button from '../Button'
import Input from "../Input"
import { getVendorByEmail } from '../../apis/VendorApi'

const VendorForm = (props) => {

    const { handleRegisterVendor } = props

    const navigate = useNavigate()

    const [newVendor, setNewVendor] = useState({ name: '', email: '', phoneNumber: '', photoProfile: '', password: '', confirmPassword: '' })

    const handleChange = (e) => {
        const { name, value } = e.target
        setNewVendor({ ...newVendor, [name]: value })
    }

    const handleLoginClick = () => {
        navigate("/")
    }

    const handleRegisterUser = async () => {
        const emailStatus = await getVendorByEmail(newVendor.email)
        console.log(emailStatus)

        if (emailStatus === 200) {
            alert('Email already exists. Please use a different email.')
        } else if (emailStatus === 404) {
            if (newVendor.password === newVendor.confirmPassword) {
                try {
                    await handleRegisterVendor(newVendor)
                    setNewVendor({
                        name: '', email: '', phoneNumber: '', photoProfile: '', password: '', confirmPassword: ''
                    })
                    alert('Registration successful.')
                    navigate('/')
                } catch (error) {
                    console.error('Error during registration:', error)
                    alert('Failed to register user. Please try again later.')
                }
            } else {
                alert('Password and Confirm Password do not match.')
            }
        } else {
            alert('Failed to check email availability. Please try again later.')
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault()
        handleRegisterUser()
    }

    return (
        <div className="container-register">
            <div className="register-form" noValidate>
                <h1>Register</h1>
                <form
                    onSubmit={handleSubmit}
                    className="row g-3 needs-validation"
                >
                    <Input
                        name="name"
                        type="text"
                        placeholder="Name"
                        value={newVendor.name}
                        onChange={handleChange}
                    />
                    <Input
                        name="email"
                        type="text"
                        placeholder="Email"
                        value={newVendor.email}
                        onChange={handleChange}
                    />
                    <Input
                        name="phoneNumber"
                        type="text"
                        placeholder="Phone Number"
                        value={newVendor.phoneNumber}
                        onChange={handleChange}
                    />
                    <Input
                        name="photoProfile"
                        type="text"
                        placeholder="Photo Profile"
                        value={newVendor.photoProfile}
                        onChange={handleChange}
                    />
                    <Input
                        name="password"
                        type="password"
                        placeholder="Password"
                        value={newVendor.password}
                        onChange={handleChange}
                    />
                    <Input
                        name="confirmPassword"
                        type="password"
                        placeholder="Confirm Password"
                        value={newVendor.confirmPassword}
                        onChange={handleChange}
                    />
                    <Button
                        name="Register"
                        className="btn btn-primary"
                    />
                </form>
                <br></br>
                <Button
                    name="Login"
                    className="btn btn-success"
                    onClick={handleLoginClick}
                />
            </div>
        </div>
    )
}

export default VendorForm