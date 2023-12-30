import axios from "axios"
import { GetAuth } from "../components/Auth"

const apiUrl = 'https://localhost:7285/api'

export const login = async (vendorData) => {
    try {
        const response = await axios.post(`${apiUrl}/AccountVendor/login`, vendorData)
        return response.data
    } catch (error) {
        console.log(error)
        throw error
    }
}

export const registerVendor = async (vendorData) => {
    try {
        const response = await axios.post(`${apiUrl}/AccountVendor/registerVendor`, vendorData)
        return response.data
    } catch (error) {
        console.log(error)
        throw error
    }
}