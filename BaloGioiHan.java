import java.util.*;

public class BaloGioiHan {
    
    // Định nghĩa lớp Item với tên
    static class Item {
        String name;   // Tên đồ vật
        int weight;    // Trọng lượng
        int value;     // Giá trị
        int quantity;  // Số lượng

        Item(String name, int weight, int value, int quantity) {
            this.name = name;
            this.weight = weight;
            this.value = value;
            this.quantity = quantity;
        }

        // Tính tỷ lệ giá trị trên trọng lượng
        double getValuePerWeight() {
            return (double) value / weight;
        }
    }

    // Phương thức giải bài toán balo có số lượng giới hạn
    public static int knapsack(Item[] items, int capacity) {
        // Sắp xếp các đồ vật theo tỷ lệ giá trị trên trọng lượng giảm dần
        Arrays.sort(items, (a, b) -> Double.compare(b.getValuePerWeight(), a.getValuePerWeight()));

        int totalValue = 0;
        int remainingCapacity = capacity;

        // Dùng để lưu thông tin số lượng các đồ vật đã chọn
        Map<String, Integer> chosenItems = new LinkedHashMap<>();

        for (Item item : items) {
            if (remainingCapacity <= 0) break;

            // Lấy số lượng tối đa có thể thêm vào balo
            int numToTake = Math.min(item.quantity, remainingCapacity / item.weight);

            if (numToTake > 0) {
                totalValue += numToTake * item.value;
                remainingCapacity -= numToTake * item.weight;

                // Lưu thông tin đồ vật đã chọn
                chosenItems.put(item.name, numToTake);
            }
        }

        // In thông tin đồ vật đã chọn và số lượng
        System.out.println("Cac do vat duoc chon va so luong:");
        for (Map.Entry<String, Integer> entry : chosenItems.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue());
        }

        return totalValue;
    }

    public static void main(String[] args) {
        // Ví dụ các đồ vật (tên, trọng lượng, giá trị, số lượng)
        Item[] items = {
            new Item(" A", 10, 60, 3), // (tên = "Đồ vật A", trọng lượng = 2, giá trị = 10, số lượng = 3)
            new Item(" B", 20, 100, 2), // (tên = "Đồ vật B", trọng lượng = 3, giá trị = 20, số lượng = 2)
            new Item("C", 30, 120, 4)  // (tên = "Đồ vật C", trọng lượng = 4, giá trị = 30, số lượng = 4)
        };

        int capacity = 50; // Dung tích balo

        // Tính giá trị tối ưu
        int maxValue = knapsack(items, capacity);

        System.out.println("Gia tri toi uu la: " + maxValue);
    }
}
