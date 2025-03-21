// using OpenCVSharp;

// class BoardDetector
// {
//     public Mat DetectBoard(Mat inputImage){
//         Mat gray = new Mat();
//         Cv2.CvtColor(inputImage, gray, ColorConversionCodes.BGR2GRAY);
        
//         Mat edges = new Mat();
//         Cv2.Canny(gray, edges, 50, 150);

//         // Find contours
//         Point[][] contours;
//         HierarchyIndex[] hierarchy;
//         Cv2.FindContours(edges, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

//         // Approximate the chessboard
//         foreach (var contour in contours)
//         {
//             double perimeter = Cv2.ArcLength(contour, true);
//             Point[] approx = Cv2.ApproxPolyDP(contour, 0.02 * perimeter, true);

//             if (approx.Length == 4)  // Possible chessboard detected
//             {
//                 Cv2.DrawContours(inputImage, new[] { approx }, -1, Scalar.Red, 3);
//             }
//         }

//         return inputImage;
//     }
// }