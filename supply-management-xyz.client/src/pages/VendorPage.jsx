import { useNavigate } from 'react-router-dom'
import { RemoveAuth } from "../components/Auth"
import VendorList from "../components/vendors/VendorList"
import VendorRepository from "../repositories/VendorRepository"
import Button from '../components/Button'

const VendorPage = () => {
    const navigate = useNavigate()
    const { vendors, handleDelete } = VendorRepository()

    const handleLogout = () => {
        RemoveAuth()
        navigate('/')
    }

    return (
        <div className="container">
            <VendorList
                vendors={vendors}
                handleDelete={handleDelete}
            />
            <Button
                name="Logout"
                className="btn btn-danger"
                onClick={handleLogout}
            />
        </div>
    )
}

export default VendorPage