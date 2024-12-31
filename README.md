# THỰC TẬP ĐỒ ÁN CƠ SỞ NGÀNH
**Tên đề tài: XÂY DỰNG PHẦN MỀM ỨNG DỤNG QUẢN LÝ CỬA HÀNG BÁN VẬT TƯ NÔNG NGHIỆP**<br>
## THÔNG TIN
**Giảng viên hướng dẫn:** TS. Nguyễn Trần Diễm Hạnh<br>
**Thời gian thực hiện:** từ ngày 04/11/2024 đến ngày 29/12/2024<br>
**Sinh viên thực hiện:** Phạm Thế Vinh<br>
**Mã số sinh viên:** 110122208 - **Mã lớp:** DA22TTC<br>
**Số điện thoại:** 0706749343 - **Email:** phamthevinhtv@gmail.com<br>
**Giới thiệu:** Đề tài này nghiên cứu xây dựng ứng dụng dạng giao diện dòng lệnh quản lý cửa hàng bán vật tư nông nghiệp sử dụng ngôn ngữ C# và .NET Framework với phương pháp lập trình hướng đối tượng. Công cụ hỗ trợ xây dựng ứng dụng là Visual Studio. Các chức năng quản lý của ứng dụng:<br>
- Quản lý danh mục các nhóm sản phẩm.<br>
- Quản lý danh mục các sản phẩm có trong cửa hàng.<br>
- Quản lý danh mục thành phần có trong sản phẩm. <br>
- Quản lý danh mục các công dụng của từng sản phẩm.<br>
- Quản lý danh mục các nhân viên của cửa hàng chịu trách nhiệm về một nhóm sản phẩm.<br>
- Quản lý danh mục thương hiệu (tên) nhà sản xuất sản phẩm.<br>
## HƯỚNG DẪN SỬ DỤNG<br>
1. Yêu cầu: Máy tính phải cài đặt Visual Studio để dễ dàng chạy và sửa lỗi.<br>
2. Cài đặt:<br>
2.1. Clone kho lưu trữ này về máy<br>
2.2. Vào thư mục đã clone về máy. Tìm đến thư mục setup. Trong thư mục setup mở thư mục AgriculturalSuppliesStore. Trong thu mục AgriculturalSuppliesStore ta thấy tập tin AgriculturalSuppliesStore.sln. Mở tập tin AgriculturalSuppliesStore.sln với Visual Studio.<br>
3. Chạy ứng dụng: Trong Visual Studio, trên thanh công cụ nhấn Start để chạy ứng dụng.<br>
4. Thao tác: Ứng dụng được chia thành các menu thao tác, trong mỗi menu các chức năng được liệt kê thành các mục và đánh số thứ tự từ 1 đến n (với n là số lượng các chức năng) và chức năng thoát được đánh số 0. Để tương tác, người dùng cần nhập số tương ứng với chức năng đã liệt kê. Tất chức năng yêu cầu nhập (bao gồm cả việc nhập lựa chọn và nhập liệu thông tin), sau khi nhập xong người dùng cần nhấn Enter để hoàn tất thao tác.<br>
5. Một số quy ước đối với các trường nhập liệu thông tin (thêm, sửa, xóa, tìm kiếm):<br>
5.1. Lệnh "exit" là lệnh thoát khẩn cấp. Khi nhập lệnh này, chương trình sẽ bỏ qua tất cả các trường sau trường hiện tại trong chức năng và thoát khỏi chức năng đó.<br>
5.2. Trường được đánh dấu "\*" là trường bắt buộc phải nhập. Chương trình sẽ cảnh báo khi trường không nhập thông tin nhưng lại nhấn Enter cho đến khi trường được nhập.<br>
5.3. Trường không đánh dấu "\*" là trường không bắt buộc nhập. Người dùng có thể bỏ qua các trường này bằng cách nhấn Enter.<br>
5.4. Trường thông tin đặc thù như ngày/tháng/năm, số điện thoại, email, số nguyên, số thực,... là các trường bắt buộc phải tuân thủ định dạng khi nhập. Tại các trường này sẽ có ghi chú gợi ý định dạng cho người dùng. Chương trình sẽ cảnh báo nếu người dùng nhập sai định dạng nhưng lại nhấn Enter cho đến khi các trường được nhập đúng định dạng.




