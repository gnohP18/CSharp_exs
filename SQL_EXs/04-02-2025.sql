SELECT * FROM practice_sql.employees;


-- 1
SELECT e.first_name, e.last_name, d.department_name, l.city, l.state_province
FROM practice_sql.employees AS e
INNER JOIN practice_sql.departments AS d ON e.department_id = d.department_id
INNER JOIN practice_sql.locations AS l ON d.location_id = l.location_id

-- 3
SELECT e.first_name, e.last_name, d.department_name, l.city, l.state_province
FROM practice_sql.employees AS e
INNER JOIN practice_sql.departments AS d ON e.department_id = d.department_id
INNER JOIN practice_sql.locations AS l ON d.location_id = l.location_id
WHERE e.first_name LIKE 'A%' OR e.last_name LIKE 'A%';

-- 4
SELECT e.employee_id, e.first_name, e.last_name, d.department_name
FROM practice_sql.employees AS e
LEFT JOIN practice_sql.departments as d ON e.department_id = d.department_id

-- 5
SELECT e.employee_id, e.first_name as first_name_employee, m.first_name as first_name_manager 
FROM practice_sql.employees AS e
INNER JOIN practice_sql.employees as m ON m.employee_id = e.manager_id

-- 6
SELECT e.first_name, e.last_name, d.department_id, d.department_name
FROM practice_sql.employees AS e
LEFT JOIN practice_sql.departments AS d ON e.department_id = d.department_id

-- 7
SELECT e.employee_id, e.first_name as first_name_employee, m.first_name as first_name_manager 
FROM practice_sql.employees AS e
LEFT JOIN practice_sql.employees as m ON m.employee_id = e.manager_id

-- 8
SELECT 
        e.employee_id, 
        e.first_name, 
        e.last_name, 
        e.department_id
    FROM practice_sql.employees AS e 
    WHERE e.last_name LIKE 'Taylor'

SELECT 
    e.first_name, 
    e.last_name, 
    d.department_id, 
    d.department_name
FROM practice_sql.departments AS d
INNER JOIN practice_sql.employees as e ON e.department_id = d.department_id
WHERE d.department_id IN 
(SELECT 
        temp.department_id
    FROM practice_sql.employees AS temp 
    WHERE temp.last_name LIKE 'Taylor')


SELECT * FROM practice_sql.job_history AS jh
WHERE jh.start_date >= '1993-01-01' AND jh.end_date <= '1997-08-31'
ORDER BY jh.start_date DESC;
-- 9
SELECT CONCAT(e.first_name, " ", e.last_name) AS full_name, j.job_title, jh.start_date
FROM practice_sql.job_history AS jh
INNER JOIN practice_sql.employees AS e ON jh.employee_id = e.employee_id
INNER JOIN practice_sql.jobs AS j ON j.job_id = jh.job_id
WHERE jh.start_date >= '1993-01-01' AND jh.end_date <= '1997-08-31'
ORDER BY jh.start_date DESC

-- 10
SELECT CONCAT(e.first_name, " ", e.last_name), d.department_name, (j.max_salary - e.salary) AS salary, j.job_title
FROM practice_sql.employees AS e
INNER JOIN practice_sql.jobs AS j ON j.job_id = e.job_id
INNER JOIN practice_sql.departments AS d ON d.department_id = e.department_id

SELECT COUNT(*)
FROM practice_sql.employees AS e
INNER JOIN practice_sql.jobs AS j ON j.job_id = e.job_id
INNER JOIN practice_sql.departments AS d ON d.department_id = e.department_id



-- 13
SELECT AVG(e.salary) FROM practice_sql.employees AS e;

-- 14 
SELECT DISTINCT j.job_title, j.min_salary
FROM practice_sql.jobs as j
LEFT JOIN practice_sql.employees AS e ON e.job_id = j.job_id
WHERE (e.salary - j.min_salary) > 1200;

-- 15
SELECT 
    j.job_title, 
    CONCAT(e.first_name, " ", e.last_name), 
    e.salary,
    CASE 
        WHEN e.salary <= 10000  THEN 'Below target' 
        WHEN e.salary > 10000 AND e.salary <= 15000  THEN 'On target' 
        ELSE 'Above target' 
    END
FROM practice_sql.jobs AS j 
INNER JOIN practice_sql.employees AS e ON e.job_id = j.job_id


-- 16
SELECT * FROM practice_sql.jobs;

SELECT 
    CONCAT(e.first_name, " ", e.last_name) AS employee_name,
    e.salary,
    d.department_name,
    d.department_id
FROM practice_sql.employees AS e  
INNER JOIN practice_sql.departments AS d ON e.department_id = d.department_id
WHERE (SELECT COUNT(*) 
       FROM practice_sql.employees AS e2
       WHERE e2.department_id = e.department_id AND e2.salary > e.salary) < 3
ORDER BY e.department_id, e.salary DESC;


-- 17 
SELECT 
    CONCAT(e.first_name, " ", e.last_name) AS full_name, 
    d.department_id, 
    e.salary,
    (j.max_salary + j.min_salary) / 2 AS avg_salary
FROM practice_sql.employees AS e
INNER JOIN practice_sql.jobs as j ON j.job_id = e.job_id
INNER JOIN practice_sql.departments AS d ON e.department_id = e.department_id
WHERE e.salary > (j.max_salary + j.min_salary) / 2
ORDER BY avg_salary / 2 ASC
