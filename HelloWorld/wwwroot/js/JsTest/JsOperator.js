/**
 * 运算符 ,
 * @param {any} 数组
 */
function reverse(arr) {
    return [arr[0], arr[1]] = [arr[1], arr[0]], arr[0] + arr[1]
}