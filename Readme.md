# Exercises Nguyen Hoang Phong

## CSharp_EX

## CSharp_EX_2

## CSharp_EX_3

## SampleDotnet_FE

### Các phần áp dụng của project

#### 1. Áp dụng JWT vào trong login
- Mỗi lần login sẽ trả về 2 loại token
  - Access token và refresh token
- Access token: claim bao gồm userId, username, jti
  - jti: mục đích là để check blacklist, multi device logout
- Refresh token:
  - 1. Lấy claim từ refresh token
  - 2. Kiểm tra xem trong redis có tồn tại jti không
  - 3. Nếu có throw exception, thông báo mail, .v.v
  - 4. Nếu không add jti vào trong redis và cấp access token, refresh token mới.
  
#### 2. Áp dụng Redis Cache để check username exist
- Hash username thanhf thứ tự bit và cấp phát vùng nhớ trong Redis
- Cần phải đồng bộ hoá Redis trước với tất cả các record username của user
