import { getVendorByEmail } from "../apis/VendorApi"
import VendorForm from "../components/vendors/VendorForm"
import AuthRepository from "../repositories/AuthRepository"

const Register = () => {
    const { handleRegisterVendor } = AuthRepository()
    return (
        <div>
            <VendorForm
                handleRegisterVendor={handleRegisterVendor}
            />
        </div>
    )
}

export default Register