using Course.Shared; // Category, Product

namespace Programming_Courses_Site.Models;

public record HomeIndexViewModel
(
  int VisitorCount,
  IList<ProgrammingCourse> Courses

);
