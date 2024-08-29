using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book_authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "book_editors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publishing_houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publishing_places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    off_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "school_Grounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    school_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_school_Grounds_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "base_ed_books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    publishing_place_id = table.Column<Guid>(type: "uuid", nullable: false),
                    publishing_house_id = table.Column<Guid>(type: "uuid", nullable: false),
                    PublishingSeries = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Appointment = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartClass = table.Column<int>(type: "integer", nullable: false),
                    EndClass = table.Column<int>(type: "integer", nullable: false),
                    leave_from_federal_books_list_at = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_base_ed_books_book_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "book_authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_base_ed_books_book_editors_editor_id",
                        column: x => x.editor_id,
                        principalTable: "book_editors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_base_ed_books_publishing_houses_publishing_house_id",
                        column: x => x.publishing_house_id,
                        principalTable: "publishing_houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_base_ed_books_publishing_places_publishing_place_id",
                        column: x => x.publishing_place_id,
                        principalTable: "publishing_places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_base_ed_books_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeStatus = table.Column<int>(type: "integer", nullable: false),
                    school_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    managing_class_id = table.Column<Guid>(type: "uuid", nullable: true),
                    surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_school_Grounds_Ground_id",
                        column: x => x.Ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "librarians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    school_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ground_id = table.Column<Guid>(type: "uuid", nullable: true),
                    IsGeneral = table.Column<bool>(type: "boolean", nullable: false),
                    surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_librarians_school_Grounds_Ground_id",
                        column: x => x.Ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_librarians_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ed_books_another_authors",
                columns: table => new
                {
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    base_ed_book_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ed_books_another_authors", x => new { x.author_id, x.base_ed_book_id });
                    table.ForeignKey(
                        name: "FK_ed_books_another_authors_base_ed_books_base_ed_book_id",
                        column: x => x.base_ed_book_id,
                        principalTable: "base_ed_books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_books_another_authors_book_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "book_authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    base_ed_book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    chapter = table.Column<int>(type: "integer", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    condition = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    in_place_count = table.Column<int>(type: "integer", nullable: false),
                    total_count = table.Column<int>(type: "integer", nullable: false),
                    current_school_ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    book_owner_school_ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    base_book_id = table.Column<Guid>(type: "uuid", nullable: true),
                    SchoolGroundId = table.Column<Guid>(type: "uuid", nullable: true),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalBooks_EducationalBooks_base_book_id",
                        column: x => x.base_book_id,
                        principalTable: "EducationalBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EducationalBooks_base_ed_books_base_ed_book_id",
                        column: x => x.base_ed_book_id,
                        principalTable: "base_ed_books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalBooks_school_Grounds_SchoolGroundId",
                        column: x => x.SchoolGroundId,
                        principalTable: "school_Grounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EducationalBooks_school_Grounds_book_owner_school_ground_id",
                        column: x => x.book_owner_school_ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalBooks_school_Grounds_current_school_ground_id",
                        column: x => x.current_school_ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalBooks_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    num = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    SubjectCount = table.Column<int>(type: "integer", nullable: false),
                    school_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    managing_teacher_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classes_employees_managing_teacher_id",
                        column: x => x.managing_teacher_id,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_classes_school_Grounds_Ground_id",
                        column: x => x.Ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ed_book_employee_rent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ed_book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    is_archived = table.Column<bool>(type: "boolean", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ed_book_employee_rent_EducationalBooks_ed_book_id",
                        column: x => x.ed_book_id,
                        principalTable: "EducationalBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_employee_rent_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ed_book_school_rent_requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    debtor_school_ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_school_ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ed_book_in_balance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requesting_book_count = table.Column<int>(type: "integer", nullable: false),
                    owner_ready_give_book_count = table.Column<int>(type: "integer", nullable: true),
                    request_status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    viewed_updates_requested_side = table.Column<bool>(type: "boolean", nullable: false),
                    viewed_updates_requesting_side = table.Column<bool>(type: "boolean", nullable: false),
                    resolved_requesting_side = table.Column<bool>(type: "boolean", nullable: false),
                    resolved_requested_side = table.Column<bool>(type: "boolean", nullable: false),
                    send_by_owner = table.Column<bool>(type: "boolean", nullable: false),
                    received_by_debtor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rent_requests_EducationalBooks_ed_book_in_ba~",
                        column: x => x.ed_book_in_balance_id,
                        principalTable: "EducationalBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rent_requests_school_Grounds_created_by",
                        column: x => x.created_by,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rent_requests_school_Grounds_debtor_school_g~",
                        column: x => x.debtor_school_ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rent_requests_school_Grounds_owner_school_gr~",
                        column: x => x.owner_school_ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ed_book_school_rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ed_book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_school_ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deptor_school_ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    closed_by_debtor = table.Column<bool>(type: "boolean", nullable: false),
                    closed_by_owner = table.Column<bool>(type: "boolean", nullable: false),
                    overdue = table.Column<bool>(type: "boolean", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    return_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rents_EducationalBooks_ed_book_id",
                        column: x => x.ed_book_id,
                        principalTable: "EducationalBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rents_school_Grounds_deptor_school_ground_id",
                        column: x => x.deptor_school_ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_school_rents_school_Grounds_owner_school_ground_id",
                        column: x => x.owner_school_ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class_subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    school_class_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_subjects_classes_school_class_id",
                        column: x => x.school_class_id,
                        principalTable: "classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_class_subjects_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    class_id = table.Column<Guid>(type: "uuid", nullable: true),
                    school_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ground_id = table.Column<Guid>(type: "uuid", nullable: false),
                    surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_students_classes_class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_students_school_Grounds_Ground_id",
                        column: x => x.Ground_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ed_books_school_rent_request_conversation_messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ed_book_rent_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    school_ground_sender_id = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    viewed_by_receiver = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ed_books_school_rent_request_conversation_messages_ed_book_~",
                        column: x => x.ed_book_rent_request_id,
                        principalTable: "ed_book_school_rent_requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_books_school_rent_request_conversation_messages_school_G~",
                        column: x => x.school_ground_sender_id,
                        principalTable: "school_Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class_subject_chapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    class_subject_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_subject_chapters_class_subjects_class_subject_id",
                        column: x => x.class_subject_id,
                        principalTable: "class_subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ed_book_student_rent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ed_book_student_rent_EducationalBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "EducationalBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ed_book_student_rent_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class_subject_chapter_ed_books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_chapter_id = table.Column<Guid>(type: "uuid", nullable: false),
                    base_ed_book_id = table.Column<Guid>(type: "uuid", nullable: true),
                    ed_book_in_balance_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_class_subject_chapter_ed_books_EducationalBooks_ed_book_in_~",
                        column: x => x.ed_book_in_balance_id,
                        principalTable: "EducationalBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_class_subject_chapter_ed_books_base_ed_books_base_ed_book_id",
                        column: x => x.base_ed_book_id,
                        principalTable: "base_ed_books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_class_subject_chapter_ed_books_class_subject_chapters_subje~",
                        column: x => x.subject_chapter_id,
                        principalTable: "class_subject_chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_base_ed_books_author_id",
                table: "base_ed_books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_base_ed_books_editor_id",
                table: "base_ed_books",
                column: "editor_id");

            migrationBuilder.CreateIndex(
                name: "IX_base_ed_books_publishing_house_id",
                table: "base_ed_books",
                column: "publishing_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_base_ed_books_publishing_place_id",
                table: "base_ed_books",
                column: "publishing_place_id");

            migrationBuilder.CreateIndex(
                name: "IX_base_ed_books_subject_id",
                table: "base_ed_books",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_subject_chapter_ed_books_base_ed_book_id",
                table: "class_subject_chapter_ed_books",
                column: "base_ed_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_subject_chapter_ed_books_ed_book_in_balance_id",
                table: "class_subject_chapter_ed_books",
                column: "ed_book_in_balance_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_subject_chapter_ed_books_subject_chapter_id",
                table: "class_subject_chapter_ed_books",
                column: "subject_chapter_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_subject_chapters_class_subject_id",
                table: "class_subject_chapters",
                column: "class_subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_subjects_school_class_id",
                table: "class_subjects",
                column: "school_class_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_subjects_subject_id",
                table: "class_subjects",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_Ground_id",
                table: "classes",
                column: "Ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_managing_teacher_id",
                table: "classes",
                column: "managing_teacher_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_classes_school_id",
                table: "classes",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_employee_rent_ed_book_id",
                table: "ed_book_employee_rent",
                column: "ed_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_employee_rent_employee_id",
                table: "ed_book_employee_rent",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rent_requests_created_by",
                table: "ed_book_school_rent_requests",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rent_requests_debtor_school_ground_id",
                table: "ed_book_school_rent_requests",
                column: "debtor_school_ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rent_requests_ed_book_in_balance_id",
                table: "ed_book_school_rent_requests",
                column: "ed_book_in_balance_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rent_requests_owner_school_ground_id",
                table: "ed_book_school_rent_requests",
                column: "owner_school_ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rents_deptor_school_ground_id",
                table: "ed_book_school_rents",
                column: "deptor_school_ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rents_ed_book_id",
                table: "ed_book_school_rents",
                column: "ed_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_school_rents_owner_school_ground_id",
                table: "ed_book_school_rents",
                column: "owner_school_ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_student_rent_BookId",
                table: "ed_book_student_rent",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ed_book_student_rent_StudentId",
                table: "ed_book_student_rent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ed_books_another_authors_base_ed_book_id",
                table: "ed_books_another_authors",
                column: "base_ed_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_books_school_rent_request_conversation_messages_ed_book_~",
                table: "ed_books_school_rent_request_conversation_messages",
                column: "ed_book_rent_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_ed_books_school_rent_request_conversation_messages_school_g~",
                table: "ed_books_school_rent_request_conversation_messages",
                column: "school_ground_sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBooks_base_book_id",
                table: "EducationalBooks",
                column: "base_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBooks_base_ed_book_id",
                table: "EducationalBooks",
                column: "base_ed_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBooks_book_owner_school_ground_id",
                table: "EducationalBooks",
                column: "book_owner_school_ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBooks_current_school_ground_id",
                table: "EducationalBooks",
                column: "current_school_ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBooks_SchoolGroundId",
                table: "EducationalBooks",
                column: "SchoolGroundId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBooks_SchoolId",
                table: "EducationalBooks",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Ground_id",
                table: "employees",
                column: "Ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_school_id",
                table: "employees",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_librarians_Ground_id",
                table: "librarians",
                column: "Ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_librarians_school_id",
                table: "librarians",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_Grounds_school_id",
                table: "school_Grounds",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_class_id",
                table: "students",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_Ground_id",
                table: "students",
                column: "Ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_school_id",
                table: "students",
                column: "school_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "class_subject_chapter_ed_books");

            migrationBuilder.DropTable(
                name: "ed_book_employee_rent");

            migrationBuilder.DropTable(
                name: "ed_book_school_rents");

            migrationBuilder.DropTable(
                name: "ed_book_student_rent");

            migrationBuilder.DropTable(
                name: "ed_books_another_authors");

            migrationBuilder.DropTable(
                name: "ed_books_school_rent_request_conversation_messages");

            migrationBuilder.DropTable(
                name: "librarians");

            migrationBuilder.DropTable(
                name: "class_subject_chapters");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "ed_book_school_rent_requests");

            migrationBuilder.DropTable(
                name: "class_subjects");

            migrationBuilder.DropTable(
                name: "EducationalBooks");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "base_ed_books");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "book_authors");

            migrationBuilder.DropTable(
                name: "book_editors");

            migrationBuilder.DropTable(
                name: "publishing_houses");

            migrationBuilder.DropTable(
                name: "publishing_places");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "school_Grounds");

            migrationBuilder.DropTable(
                name: "schools");
        }
    }
}
