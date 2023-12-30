import { registerVendor } from "../apis/AccountVendorApi"

export default function AuthRepository() {

    const handleRegisterVendor = async (newVendor) => {
        try {
            await registerVendor(newVendor)
        } catch (error) {
            console.error("Error create vendor", error)
        }
    }

    return { handleRegisterVendor }
}