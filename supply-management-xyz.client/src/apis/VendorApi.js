import axios from "axios"
import { GetAuth } from "../components/Auth"

const apiUrl = 'https://localhost:7285/api'

export const getAll = async () => {
    const token = await GetAuth()
    const headers = {
        Authorization: `Bearer ${token}`,
    }
    try {
        const response = await axios.get(`${apiUrl}/Vendor`, { headers })
        return response?.data?.data || []
    } catch (error) {
        if (error.response.status === 404) {
            return []
        } else {
            throw error
        }
    }
}

export const create = async (vendorData) => {
    const token = await GetAuth()
    const headers = {
        Authorization: `Bearer ${token}`,
    }
    try {
        const response = await axios.post(`${apiUrl}/Vendor`, vendorData, { headers })
        return response.data
    } catch (error) {
        console.log(error)
        throw error
    }
}

export const update = async (updatedData) => {
    const token = await GetAuth()
    const headers = {
        Authorization: `Bearer ${token}`,
    }
    try {
        const response = await axios.put(`${apiUrl}/Vendor`, updatedData, { headers })
        return response.data
    } catch (error) {
        console.log(error)
        throw error
    }
}

export const remove = async (vendorGuid) => {
    const token = await GetAuth()
    const headers = {
        Authorization: `Bearer ${token}`,
    }
    try {
        const response = await axios.delete(`${apiUrl}/Vendor/${vendorGuid}`, { headers })
        return response
    } catch (error) {
        console.log(error)
        if (error.response && error.response.status === 400) {
            return 400
        }
    }
}

export const GetVendorById = async (guid) => {
    const token = await GetAuth()
    const headers = {
        Authorization: `Bearer ${token}`,
    }
    try {
        const response = await axios.get(`${apiUrl}/Vendor/${guid}`, { headers })
        return response
    }
    catch (error) {
        if (error.response && error.response.status === 404) {
            return 404
        }
        console.error('Error during API request:', error)
    }
}

export const getVendorByEmail = async (email) => {
    try {
        const response = await axios.get(`${apiUrl}/Vendor/ByEmail/${email}`)
        return response
    } catch (error) {
        if (error.response && error.response.status === 404) {
            return 404
        }
        console.error('Error during API request:', error)
    }
}