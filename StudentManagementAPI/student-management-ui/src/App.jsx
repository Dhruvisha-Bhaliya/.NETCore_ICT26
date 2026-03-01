import { useEffect, useState } from "react";

function App() {
    const baseUrl = "https://localhost:7006/api";
    const [students, setStudents] = useState([]);
    const [courses, setCourses] = useState([]);
    const [enrollments, setEnrollments] = useState([]);

    const [selectedStudent, setSelectedStudent] = useState("");
    const [selectedCourse, setSelectedCourse] = useState("");
    const [enrollmentDate, setEnrollmentDate] = useState("");

    const [editId, setEditId] = useState(null);

    // ================= FETCH DATA =================

    const fetchStudents = async () => {
        try {
            const res = await fetch(`${baseUrl}/students`);
            const data = await res.json();
            console.log("Students:", data);
            setStudents(data);
        } catch (error) {
            console.error("Student Fetch Error:", error);
        }
    };

    const fetchCourses = async () => {
        try {
            const res = await fetch(`${baseUrl}/courses`);
            const data = await res.json();
            console.log("Courses:", data);
            setCourses(data);
        } catch (error) {
            console.error("Course Fetch Error:", error);
        }
    };

    const fetchEnrollments = async () => {
        try {
            const res = await fetch(`${baseUrl}/enrollments`);
            const data = await res.json();
            console.log("Enrollments:", data);
            setEnrollments(data);
        } catch (error) {
            console.error("Enrollment Fetch Error:", error);
        }
    };

    useEffect(() => { const loadData = async () => { await fetchStudents(); await fetchCourses(); await fetchEnrollments(); }; loadData(); }, []);

    // ================= SAVE =================

    const saveEnrollment = async () => {
        if (!selectedStudent || !selectedCourse || !enrollmentDate) {
            alert("Please fill all fields");
            return;
        }

        const enrollmentData = {
            id: editId,
            studentId: parseInt(selectedStudent),
            courseId: parseInt(selectedCourse),
            enrollmentDate: enrollmentDate,
        };

        try {
            if (editId) {
                await fetch(`${baseUrl}/enrollments/${editId}`, {
                    method: "PUT",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(enrollmentData),
                });
            } else {
                await fetch(`${baseUrl}/enrollments`, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(enrollmentData),
                });
            }

            resetForm();
            fetchEnrollments();
        } catch (error) {
            console.error("Save Error:", error);
        }
    };

    // ================= DELETE =================

    const deleteEnrollment = async (id) => {
        try {
            await fetch(`${baseUrl}/enrollments/${id}`, {
                method: "DELETE",
            });
            fetchEnrollments();
        } catch (error) {
            console.error("Delete Error:", error);
        }
    };

    // ================= EDIT =================

    const editEnrollment = (e) => {
        setEditId(e.id);
        setSelectedStudent(e.studentId);
        setSelectedCourse(e.courseId);
        setEnrollmentDate(e.enrollmentDate?.substring(0, 10));
    };

    const resetForm = () => {
        setSelectedStudent("");
        setSelectedCourse("");
        setEnrollmentDate("");
        setEditId(null);
    };

    // ================= UI =================

    return (
        <div style={{ padding: "40px", fontFamily: "Arial" }}>
            <h2>🎓 Enrollment Management System</h2>

            <div style={{ marginBottom: "20px" }}>
                {/* Student Dropdown */}
                <select
                    value={selectedStudent}
                    onChange={(e) => setSelectedStudent(e.target.value)}
                >
                    <option value="">Select Student</option>
                    {students.map((s) => (
                        <option key={s.id} value={s.id}>
                            {s.name || s.studentName}
                        </option>
                    ))}
                </select>

                {/* Course Dropdown */}
                <select
                    value={selectedCourse}
                    onChange={(e) => setSelectedCourse(e.target.value)}
                >
                    <option value="">Select Course</option>
                    {courses.map((c) => (
                        <option key={c.id} value={c.id}>
                            {c.courseName || c.name}
                        </option>
                    ))}
                </select>

                {/* Date Picker */}
                <input
                    type="date"
                    value={enrollmentDate}
                    onChange={(e) => setEnrollmentDate(e.target.value)}
                />

                <button onClick={saveEnrollment}>
                    {editId ? "Update" : "Add"}
                </button>
            </div>

            {/* Enrollment Table */}
            <table border="1" cellPadding="10">
                <thead>
                    <tr>
                        <th>Student</th>
                        <th>Course</th>
                        <th>Date</th>
                        <th>Actions</th>
                    </tr>
                </thead>

                <tbody>
                    {enrollments.map((e) => (
                        <tr key={e.id}>
                            <td>{e.student?.name || e.student?.studentName}</td>
                            <td>{e.course?.courseName || e.course?.name}</td>
                            <td>{e.enrollmentDate?.substring(0, 10)}</td>
                            <td>
                                <button onClick={() => editEnrollment(e)}>Edit</button>
                                <button onClick={() => deleteEnrollment(e.id)}>
                                    Delete
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default App;