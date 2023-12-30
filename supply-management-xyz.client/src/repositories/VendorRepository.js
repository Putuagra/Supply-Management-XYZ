import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { create, getAll, getVendorByEmail, remove, update } from '../apis/VendorApi'
import { GetAuth, GetTokenClaim, RemoveAuth } from '../components/Auth'

export default function VendorRepository() {
    const [vendors, setVendors] = useState([])
    const navigate = useNavigate()

    useEffect(() => {
        const storedToken = GetAuth()
        const isAuthenticated = storedToken !== null
        if (isAuthenticated) {
            const decode = GetTokenClaim(storedToken)
            fetchData()
            const expirationTime = decode.exp * 1000
            const currentTime = Date.now()
            if (currentTime > expirationTime) {
                RemoveAuth()
                navigate('/login')
            }      
        }
    }, [])

    const fetchData = async () => {
        try {
            const data = await getAll()
            setVendors(data)
        } catch (error) {
            console.error("Error fetching data: ", error)
        }
    }

    const handleCreate = async (newVendor) => {
        try {
            await create(newVendor)
            fetchData()
        } catch (error) {
            console.error("Error create vendor", error)
        }
    }

    const handleUpdate = async (updatedVendor) => {
        try {
            await update(updatedVendor)
            fetchData()
        } catch (error) {
            console.error('Error editing vendor:', error)
        }
    }

    const handleDelete = async (vendorGuid) => {
        try {
            const response = await remove(vendorGuid)
            if (vendors.length === 1) {
                setVendors([])
            }
            fetchData()
            return response
        } catch (error) {
            console.error('Error deleting vendor:', error)
        }
    }

    const handleGetVendorById = async (guid) => {
        try {
            return await GetVendorById(guid)
        } catch (error) {
            console.error('Error sending get vendor request:', error)
        }
    }

    const handleGetVendorByEmail = async (email) => {
        try {
            return await getVendorByEmail(email)
        } catch (error) {
            console.error('Error sending get user request:', error)
        }
    }

    return { vendors, handleUpdate, handleDelete, handleGetVendorById, handleGetVendorByEmail }
}