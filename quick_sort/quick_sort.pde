int[] num = {10, 5, 16, 28, 14, 8, 1, 4, 21, 35};
void setup(){
  quick_sort(num, 0, num.length - 1);
  for(int i=0; i<num.length; i++){
    println(num[i]);
  }
}

void quick_sort(int array[], int left, int right){
  int pivot = array[(left + right) / 2];
  int i = left;
  int j = right;
  int temp;
  
  while(true){
    //左側に基準値より大きい値があるかを確認
    while(array[i] < pivot){
      ++i;
    }
    //右側に基準値より小さい値があるかを確認
    while(array[j] > pivot){
      --j;
    }
    
    //値がぶつかったら終了
    if(i >= j){
      break;
    }
    
    //値を入れ替える
    temp = array[i];
    array[i] = array[j];
    array[j] = temp;
    i++;
    j--;
  }
  
  //開始点になるまで左側の分割を繰り返す
  if(left < i - 1){
    quick_sort(array, left, i - 1);
  }
  
  //終了点になるまで右側の分割を繰り返す
  if(right > j + 1){
    quick_sort(array, j + 1, right);
  }
}