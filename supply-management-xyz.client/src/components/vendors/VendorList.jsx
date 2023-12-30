import { useNavigate } from 'react-router-dom'
import Button from "../Button"

export default function VendorList(props) {

    const navigate = useNavigate()
    const { vendors, handleDelete } = props

    const handleUpdateClick = (guid) => {
        const vendorToEdit = vendors.find((vendor) => vendor.guid === guid)
        const prevVendorEmail = vendorToEdit.email
        const prevVendorName = vendorToEdit.name
        const prevVendorPhone = vendorToEdit.phoneNumber
        const prevVendorSector = vendorToEdit.sector
        const prevVendorType = vendorToEdit.type
        const prevVendorPhoto = vendorToEdit.photoProfile
        const prevVendorAdminApprove = vendorToEdit.isAdminApprove
        const prevVendorManagerApprove = vendorToEdit.isManagerApprove
        navigate("/update-vendor", {
            state: {
                guid,
                prevVendorEmail: prevVendorEmail,
                prevVendorEmail: prevVendorEmail,
                prevVendorName: prevVendorName,
                prevVendorPhone: prevVendorPhone,
                prevVendorSector: prevVendorSector,
                prevVendorType: prevVendorType,
                prevVendorPhoto: prevVendorPhoto,
                prevVendorAdminApprove: prevVendorAdminApprove,
                prevVendorManagerApprove: prevVendorManagerApprove
            }
        })
    }

    return (
        <div>
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone Number</th>
                        <th>Sector</th>
                        <th>Type</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {Array.isArray(vendors) && vendors.length > 0 ? (
                        vendors.map((data, index) => (
                            <tr key={index}>
                                <td>
                                    {data.name}
                                </td>
                                <td>
                                    {data.email}
                                </td>
                                <td>
                                    {data.phoneNumber}
                                </td>
                                <td>
                                    {data.sector}
                                </td>
                                <td>
                                    {data.type}
                                </td>
                                <td>
                                    <Button
                                        name="Edit"
                                        className="btn btn-primary"
                                        onClick={() => {
                                            handleUpdateClick(data.guid)
                                        }}
                                    />
                                    <Button
                                        name="Delete"
                                        className="btn btn-danger"
                                        onClick={() => handleDelete(data.guid)}
                                    />
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="3">No vendor data available.</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
}