import { useNavigate } from 'react-router-dom'
import { getVendorByEmail } from '../../apis/VendorApi'
import { useState } from 'react'
import { useEffect } from 'react'
import Input from '../Input'
import Button from '../Button'

const VendorUpdate = (props) => {

    const { guid, prevVendorEmail, prevVendorName, prevVendorPhone, prevVendorSector, prevVendorType, prevVendorPhoto, prevVendorAdminApprove, prevVendorManagerApprove, handleUpdate, handleGetVendorById } = props
    const navigate = useNavigate()

    const [updateVendor, setUpdateVendor] = useState({ name: '', email: '', phoneNumber: '', photoProfile: '', sector: '', type: '', isAdminApprove: prevVendorAdminApprove, isManagerApprove: prevVendorManagerApprove })

    const handleInputChange = (e) => {
        const { name, value } = e.target
        setUpdateVendor({ ...updateVendor, [name]: value })
    }

    const getUpdateVendor = async (guid) => {
        try {
            const response = await handleGetVendorById(guid)
            if (prevVendorEmail && prevVendorName && prevVendorPhone && prevVendorSector && prevVendorType && prevVendorPhoto) {
                setUpdateVendor(response?.data?.data)
            }
        } catch (error) {
            console.log('An unexpected error occurred.', error)
        }
    }

    useEffect(() => {
        getUpdateVendor(guid)
    }, [])

    const handleUpdateVendor = async (data) => {
        const emailStatus = await getVendorByEmail(data.email)

        if (emailStatus === 404 || (prevVendorEmail === data.email && prevVendorName === data.name && prevVendorPhone === data.phoneNumber)) {
            try {
                await handleUpdate(data)
                alert('Update data successful.')
                navigate('/vendor')
            } catch (error) {
                console.error('Error during update data:', error)
                alert('Failed to update user. Please try again later.')
            }
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault()
        handleUpdateVendor(updateVendor)
    }

    return (
        <div className="row">
            <div className="col-lg-12" noValidate>
                <form
                    onSubmit={handleSubmit}
                    className="row g-3 needs-validation"
                >
                    <Input
                        name="name"
                        type="text"
                        placeholder="Name"
                        value={updateVendor.name}
                        onChange={handleInputChange}
                    />
                    <Input
                        name="email"
                        type="text"
                        placeholder="Email"
                        value={updateVendor.email}
                        onChange={handleInputChange}
                    />
                    <Input
                        name="phoneNumber"
                        type="text"
                        placeholder="Phone Number"
                        value={updateVendor.phoneNumber}
                        onChange={handleInputChange}
                    />
                    <Input
                        name="photoProfile"
                        type="text"
                        placeholder="Photo"
                        value={updateVendor.photoProfile}
                        onChange={handleInputChange}
                    />
                    <Input
                        name="sector"
                        type="text"
                        placeholder="Sector"
                        value={updateVendor.sector}
                        onChange={handleInputChange}
                    />
                    <Input
                        name="type"
                        type="text"
                        placeholder="Type"
                        value={updateVendor.type}
                        onChange={handleInputChange}
                    />
                    <Input
                        name="isAdminApprove"
                        type="hidden"
                        value={updateVendor.isAdminApprove}
                    />
                    <Input
                        name="isManagerApprove"
                        type="hidden"
                        value={updateVendor.isManagerApprove}
                    />
                    <Button
                        name="Save"
                        className="btn btn-success"
                    />
                </form>
            </div>
        </div>
        )
}

export default VendorUpdate