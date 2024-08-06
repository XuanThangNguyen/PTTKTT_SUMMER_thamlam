import java.util.Arrays;
import java.util.Comparator;

class DoVat {
    String ten;
    float trongLuong;
    float giaTri;
    float donGia;
    int phuongAn;

    public DoVat(String ten, float trongLuong, float giaTri) {
        this.ten = ten;
        this.trongLuong = trongLuong;
        this.giaTri = giaTri;
        this.donGia = giaTri / trongLuong;
        this.phuongAn = 0;
    }
}

public class BaiToanBalo1 {

    public static void main(String[] args) {
        // Dữ liệu được định nghĩa sẵn
        DoVat[] dsdv = {
            new DoVat("Vat A", 10f, 60.0f),
            new DoVat("Vat B", 20f, 100.0f),
            new DoVat("Vat C", 30f, 120.0f)
        };
        float W = 50; // Trọng lượng tối đa của ba lô

        // Sắp xếp các đồ vật theo đơn giá từ cao đến thấp
        Arrays.sort(dsdv, Comparator.comparingDouble(d -> -d.donGia));

        float tongGiaTri = 0;
        for (DoVat doVat : dsdv) {
            if (W == 0) {
                break; // Ba lô đã đầy
            }

            // Số lượng tối đa của đồ vật này mà chúng ta có thể lấy
            int soLuong = (int) (W / doVat.trongLuong);
            doVat.phuongAn = soLuong;
            tongGiaTri += soLuong * doVat.giaTri;
            W -= soLuong * doVat.trongLuong;
        }

        // In kết quả
        System.out.println("Phuong an toi uu: ");
        for (DoVat doVat : dsdv) {
            if (doVat.phuongAn > 0) {
                System.out.println("Ten: " + doVat.ten + 
                                   ", So luong: " + doVat.phuongAn + 
                                   ", Trong luong: " + doVat.trongLuong * doVat.phuongAn + 
                                   ", Gia tri: " + doVat.giaTri * doVat.phuongAn);
            }
        }

        System.out.println("Tong gia tri lon nhat co the: " + tongGiaTri);
    }
}
