import { useNavigate } from 'react-router-dom'
import { useLocation } from 'react-router-dom'
import VendorUpdate from '../components/vendors/VendorUpdate'
import VendorRepository from '../repositories/VendorRepository'

const VendorUpdatePage = () => {

    const location = useLocation()
    const guid = location.state?.guid
    const prevVendorEmail = location.state?.prevVendorEmail
    const prevVendorName = location.state?.prevVendorName
    const prevVendorPhone = location.state?.prevVendorPhone
    const prevVendorSector = location.state?.prevVendorSector
    const prevVendorType = location.state?.prevVendorType
    const prevVendorPhoto = location.state?.prevVendorPhoto
    const prevVendorAdminApprove = location.state?.prevVendorAdminApprove
    const prevVendorManagerApprove = location.state?.prevVendorManagerApprove
    const { handleUpdate, handleGetVendorById } = VendorRepository()

    return (
        <div className="container">
            <VendorUpdate
                guid={guid}
                prevVendorEmail={prevVendorEmail}
                prevVendorName={prevVendorName}
                prevVendorPhone={prevVendorPhone}
                prevVendorSector={prevVendorSector}
                prevVendorType={prevVendorType}
                prevVendorPhoto={prevVendorPhoto}
                prevVendorAdminApprove={prevVendorAdminApprove}
                prevVendorManagerApprove={prevVendorManagerApprove }
                handleUpdate={handleUpdate}
                handleGetVendorById={handleGetVendorById}
            />
        </div>
    )
}

export default VendorUpdatePage